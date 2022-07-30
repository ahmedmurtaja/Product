using Product.API.Data;
using Product.API.Dtos;
using Product.API.Exceptions;
using Product.API.Models;
using System;
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

        public int Create(CreateProductDto dto)
        {
            var nameIsExist=_db.Products.Any(x => x.Name == dto.Name);
            if (nameIsExist)
            {
                throw new DublicatedProductException();
            }
            if(dto.Price<dto.Cost)
            {
                throw new PriceLessCostException();
            }
            var product = new ProductEntity();
            product.Name = dto.Name;
            product.Cost=dto.Cost;
            product.Price=dto.Price;
            _db.Products.Add(product);
            _db.SaveChanges();
            return product.Id;
        }
        public int Update(UpdateProductDto dto)
        {
            try
            {
                var product = _db.Products.Find(dto.Id);
                product.Name = dto.Name;
                product.Cost = dto.Cost;
                product.Price = dto.Price;
                _db.Products.Update(product);
                _db.SaveChanges();
                return product.Id;
            }catch(Exception e)
            {
                return -1;
            }
        }

    }
}
