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
    public class OrderManager : IOrderService
    {
        IOrderDal _ıOrderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _ıOrderDal = orderDal;
        }
        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(_ıOrderDal.GetList().ToList());
        }
    }
}
