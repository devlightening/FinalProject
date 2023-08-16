using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category> //you configured IEntityRepositroy with Category then we are taking directliy methods...!
    {

    }
}



//List<Category> GetAll();
//void Add(Category category);
//void Update(Category category);                    //Gerek kalmadı çünkü IEntityRepository<Category> yaptık.
//void Delete(Category category);
//List<Product> GetAllCategory(int categoryId);


