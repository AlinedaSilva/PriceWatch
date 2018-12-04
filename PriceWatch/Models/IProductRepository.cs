using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatch.Models
{
    interface IProductRepository
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync(string query, int offset, int limit = 10);
    }
}


