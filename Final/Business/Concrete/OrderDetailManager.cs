using Business.Abstract;
using Core.Utilities.Results;
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
        public IDataResult<List<OrderDetail>> GetList(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
