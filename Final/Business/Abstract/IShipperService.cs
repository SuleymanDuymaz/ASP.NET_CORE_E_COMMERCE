using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShipperService
    {
        IDataResult<List<Shipper>> GetList();
        IDataResult<Shipper> GetById(int shipperId);
        IResult Update(Shipper shipper);
        IResult Add(Shipper shipper);
    }
}
