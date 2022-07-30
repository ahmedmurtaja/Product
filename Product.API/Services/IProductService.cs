using Product.API.Dtos;
using Product.API.Models;
using System.Collections.Generic;

namespace Product.API.Services
{
    public interface IProductService
    {
        ProductEntity Get(int Id);
        List<ProductEntity> GetAll();
        void Delete(int Id);
        public int Create(CreateProductDto dto);
        public int Update(UpdateProductDto dto);

    }
}