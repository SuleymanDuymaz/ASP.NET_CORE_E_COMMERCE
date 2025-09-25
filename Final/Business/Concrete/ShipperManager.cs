using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    [SecuredOperation("admin")]
    public class ShipperManager : IShipperService
    {
        IShipperDal _ıShipperDal;
        public ShipperManager(IShipperDal shipperDal)
        {
            _ıShipperDal = shipperDal;
        }

        public IResult Add(Shipper shipper)
        {
            _ıShipperDal.Add(shipper);
            return new SuccessResult(Messages.ShipperAdded);
        }

        public IDataResult<Shipper> GetById(int shipperId)
        {
            return new SuccessDataResult<Shipper>(_ıShipperDal.Get(p => p.ShipperId == shipperId));
        }

        public IDataResult<List<Shipper>> GetList()
        {
            return new SuccessDataResult<List<Shipper>>(_ıShipperDal.GetList().ToList());
        }

        public IResult Update(Shipper shipper)
        {
            _ıShipperDal.Update(shipper);
            return new SuccessResult(Messages.ShipperUpdated);
        }
    }
}
