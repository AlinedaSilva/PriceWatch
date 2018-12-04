using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PriceWatch.Models;

namespace PriceWatch.Controllers
{
    public class PriceWatchController : Controller
    {
        // GET: PriceWatch
        private IPriceWatchRepository _priceWatchRepository;
        private IProductRepository _productRepository;
        // dependency injection (ninject)

        public PriceWatchController(IPriceWatchRepository priceWatchRepository, IProductRepository productRepository)
        {
            _priceWatchRepository = priceWatchRepository;
            _productRepository = productRepository;
        }
        public async Task<ActionResult> List()
        {
            // If user isn't authenticated, he must login to see his price watch
            if (!User.Identity.IsAuthenticated)
            {
                // redirect
                return RedirectToAction("Login", "Account");
            }
            //get user's price watch
            var userPriceWatchList = _priceWatchRepository.GetPriceWatches(User.Identity.GetUserId());

            // make view model
            var viewLst = new List<PriceWatchViewModel>();

            // indicator to save changes to database (if new entry is added)
            bool saveChanges = false;

            foreach (var pricewatch in userPriceWatchList)
            {
                // get last price added to that price watch
                var lastUpdate = pricewatch.Entries?.OrderByDescending(d => d.Date).FirstOrDefault();

                // if ther is a new date to search for
                if (lastUpdate.Date.Date < DateTime.Today)
                {
                    // get current product price from the api
                    var products = await _productRepository.GetProductsAsync(pricewatch.ProductName, 0, 1);
                    var productNow = products.FirstOrDefault();

                    //if product was found
                    if (productNow != null)
                    {
                        //indicate if the product price has gone up dow or stayed same

                        PriceIndicator indicator = PriceIndicator.Same;

                        if (productNow?.Price > lastUpdate?.Price)
                        {
                            indicator = PriceIndicator.Up;
                        }
                        if (productNow?.Price < lastUpdate?.Price)
                        {
                            indicator = PriceIndicator.Down;
                        }

                        var newEntry = new PriceWatchEntry()
                        {
                            Date = DateTime.Now,
                            Price = productNow.Price,
                            PriceIndicator = indicator
                        };
                        // must update the database at the end (cannot update now because we are in the middle of a query)
                        pricewatch.Entries.Add(newEntry);
                        lastUpdate = newEntry;
                        saveChanges = true;
                    }
                }
                //create view model for that price watch
                var viewModel = new PriceWatchViewModel()
                {
                    Id = pricewatch.Id,
                    CreationDate = pricewatch.CreationDate,
                    LastPrice = lastUpdate?.Price,
                    ImageUrl = pricewatch?.ImageUrl,
                    LastUpdate = lastUpdate?.Date,
                    PriceIndicatorGlyphicon = PriceWatchEntryViewModel.GetPriceIndicatorGlyphicon(lastUpdate?.PriceIndicator),
                    PriceIndicatorBgColor = PriceWatchEntryViewModel.GetPriceIndicatorBgColor(lastUpdate?.PriceIndicator),
                    ProductDescription = pricewatch.ProductDescription,
                    ProductName = pricewatch.ProductName
                };
                // add all entries
                viewModel.Entries = new List<PriceWatchEntryViewModel>();

                //sort by date descending (latest first)
                foreach (var entry in pricewatch.Entries.OrderByDescending(d => d.Date))
                {
                    //create view model for the entry
                    var viewModelEntry = new PriceWatchEntryViewModel()
                    {
                        Date = entry.Date,
                        Id = entry.Id,
                        Price = entry.Price,
                        PriceIndicator = entry.PriceIndicator
                    };

                    viewModel.Entries.Add(viewModelEntry);
                }

                // add view model to the view model list
                viewLst.Add(viewModel);
            }
            // update the database if needed
            if (saveChanges)
            {
                _priceWatchRepository.Save();
            }
            // return the viewModel list to the view 
            return View("PriceWatchView", viewLst);
        }

    }
}