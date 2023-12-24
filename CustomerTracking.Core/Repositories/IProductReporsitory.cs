using CustomerTracking.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Core.Repositories
{
    public interface IProductReporsitory:IGenericRepository<Product> 
    {
        Task<List<Product>> GetProductsWithCategory();
    }
}
