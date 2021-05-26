using SportsStore.DAL;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EFProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> Products => _dbContext.Products;
    }
}
