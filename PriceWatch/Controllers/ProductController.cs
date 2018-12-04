using PriceWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PriceWatch.Controllers
{
    public class ProductController : Controller
    {
        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private IProductRepository _productRepository;
        private IPriceWatchRepository _priceWatchRepository;

        public ProductController(IProductRepository productRepository, IPriceWatchRepository priceWatchRepository)
        {
            _productRepository = productRepository;
            _priceWatchRepository = priceWatchRepository;
        }
        public async Task<ActionResult> Get(string query, int offset)
        {
            // query for products in the api
            var products = await _productRepository.GetProductsAsync(query, offset);
            // get current user's price watch
            var myPriceWatch = _priceWatchRepository.GetPriceWatches(User.Identity.GetUserId());

            // if product is present in the user's price watch, must set the indicator so it becomes green on the page and he can't add it again
            foreach (var product in products)
            {
                if (myPriceWatch.Any(d => d.ProductId == product.Id))
                    product.HasPriceWatch = true;
            }
            //send back the parameters to the page (used for pagination)
            RouteData.Values.Add("query", query);
            RouteData.Values.Add("offset", offset);

            return View("ProductView", products);
        }
    }
}