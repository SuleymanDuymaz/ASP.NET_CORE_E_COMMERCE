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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _ıOrderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _ıOrderDetailDal = orderDetailDal;
        }
        public IDataResult<List<OrderDetail>> GetList(int orderId)
        {
            return new SuccessDataResult<List<OrderDetail>>(_ıOrderDetailDal.GetList(p => p.OrderID == orderId).ToList());

        }
    }
}
