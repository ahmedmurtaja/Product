using Product.API.Data;
using Product.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ProductEntity> GetAll()
        {
            var products = _db.Products.ToList();
            return products;
        }

        public ProductEntity Get(int Id)
        {
            var product = _db.Products.Find(Id);
            return product;
        }

        public void Delete(int Id)
        {
            var product = _db.Products.Find(Id);
            _db.Remove(product);
            _db.SaveChanges();
        }

    }
}
