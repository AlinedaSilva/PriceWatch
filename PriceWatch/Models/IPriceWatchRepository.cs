using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceWatch.Models
{
    public interface IPriceWatchRepository
    {
        IEnumerable<PriceWatch> GetPriceWatches(string UserId);
        void Create(PriceWatch priceWatch);
        void Remove(long priceWatchId);
        void Save();
    }
}

