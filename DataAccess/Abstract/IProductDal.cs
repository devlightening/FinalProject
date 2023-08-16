using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    //we are creating methods, add delete update like that...!
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