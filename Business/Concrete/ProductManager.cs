using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Claim     
        //[SecuredOperaion("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Polyformism:
            IResult result = BusinessRules.Run(CheckIfProductExists(product.ProductName),
               CheckIfProductCountOfCategoryCorrect(product.CategoryId),
               CheckIfCategoryLimitExciteded());
            if (result!=null)
            {
                return result;
            }
            //business codes
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            /* 
             ValidationTool.Validate(new ProductValidator(), product); ======> [ValidationAspect(typeof(ProductValidator))]28
             Validation codes
             if (product.UnitPrice <= 0)
             {
                 return new ErrorResult(Messages.UnitPriceInvalid);
             }
             if (product.ProductName.Length < 2)
             {
                 //magic strings 
                 return new ErrorResult(Messages.ProductNameInvalid);
             }
            */
        }
        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll
                (p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult <List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p=>p.CategoryId==categoryId).Count;
            if (result >=10) 
            {
                return new ErrorResult(Messages.ProductCountOfCategory);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductExists(string productName)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryOf(string productName)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExciteded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExciteded);
            }
            return new SuccessResult();
        }
    }
}
