using CustomerTracking.Core.Models.Entities;
using CustomerTracking.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductReporsitory
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
            return await _context.Products.Include(a=>a.Category).ToListAsync();
        }
    }
}
