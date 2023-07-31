using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring


// Code Refactoring
// List<Product> GetAll();

///* List<Product> GetAllByCategoryId(Expression<Func<Product, bool>> filter = null)*/
// void Add(Product entity);
// void Update(Product entity);
// void Delete(Product entity);

// //List<Product> GetAllByCategory(int categoryId);