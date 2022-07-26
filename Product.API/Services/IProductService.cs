using Product.API.Models;
using System.Collections.Generic;

namespace Product.API.Services
{
    public interface IProductService
    {
        ProductEntity Get(int Id);
        List<ProductEntity> GetAll();
        void Delete(int Id);
    }
}