
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // if we want to filter then we have to use (generic constraint)...!
    //generic constraint..!
    //class:reference type..!
    //IEntity= it can be reference type or reference types include of entities...!
    //new=it should be be renewable
    public interface IEntityRepository<T> where T : class, IEntity, new()//We used the (generic Repository design pattern)...!
        //T= it can be reference type or reference types include of entities...!
    {

        List<T> GetAll(Expression<Func<T, bool>>? filter = null);//Delegate...! //we are taking all informations as a List...! //if want ,we dont have to filter...!
        //when we want to taking information with filter...!
        //for example return _productDal.GetAll(p=>p.categoryId==2) like that we can use this expression syntax...!

        T Get(Expression<Func<T, bool>> filter);//just one we are taking entity..!but here we have to filter them
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
