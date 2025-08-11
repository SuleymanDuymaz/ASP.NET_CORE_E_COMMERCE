using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ıCustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _ıCustomerDal = customerDal;
        }
        public IDataResult<List<Customer>> GetList()
        {
            return new SuccessDataResult<List<Customer>>(_ıCustomerDal.GetList().ToList());
        }
    }
}
