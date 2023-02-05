using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
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
        IProductDal _productDal;    
        public ProductManager(IProductDal productDal)
        {
            //zayıf bağımlılık
            _productDal = productDal;
        }

        

        //AOP*AUTOFac
        //[LogAspect]
        //[Validate]
        //[RemoveCache]
        //[Transaction]
        //[Performance]
        public IResult Add(Product product)
        {

            //bu alanlar core/crosscuttingconcerns validationtool alanında kodlandı çağırma işlemi kaldı sadece

            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator=new ProductValidator();
            //var result=productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);
            return new Result(true,"Ürün Eklendi");
        }

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
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min & p.UnitPrice<=max), "Ürünler listelendi");
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.Maintenance);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());

        }
    }
}
