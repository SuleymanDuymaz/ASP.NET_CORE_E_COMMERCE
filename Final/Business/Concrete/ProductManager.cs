using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{


    //iş sınıfı başka sınıfları newlemez
    public class ProductManager : IProductService
    {

        //entity manager başka bir dal ı kullanmaz.
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            //zayıf bağımlılık
            _productDal = productDal;
            _categoryService = categoryService;
        }



        //AOP*AUTOFac
        //[LogAspect]
        //[Validate]
        //[RemoveCache]
        //[Transaction]
        //[Performance]
        [SecuredOperation("product.add, admin")]
       
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        //IProductService.Get in cache olayını siler.      [CacheRemoveAspect("Get")] böyle kullanılırsa içinde get olan her şeyi siler.
        public IResult Add(Product product)
        {

            //bu alanlar core/crosscuttingconcerns validationtool alanında kodlandı çağırma işlemi kaldı sadece
            //log
            //cache
            //yetkinlendirme
            //transaction   
            //performancce

       

            IResult result1 = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID),
                CheckIfProductNameExist(product.ProductName));

            _productDal.Add(product);


            //if (result!=null)
            //{
            //    return result;  
            //}

            //_productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);



        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==16)
            {
                return new ErrorDataResult<List<Product>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryID==id), "Ürünler listelendi"); 

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.Price>=min & p.Price<=max), "Ürünler listelendi");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p=>p.CategoryID==categoryId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult ChechkIfCategoryNameExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>=15)
            {
               return new ErrorResult(Messages.CategoryCountExceded);
            }
            return new SuccessResult();
        }
    }
}
