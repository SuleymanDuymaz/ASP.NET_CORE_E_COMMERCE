using Business.Abstract;
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
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _ıSupplierDal;
        public SupplierManager(ISupplierDal supplierDal)
        {
            _ıSupplierDal = supplierDal;


        }
        public IResult Add(Supplier supplier)
        {
            _ıSupplierDal.Add(supplier);
            return new SuccessResult(Messages.SupplierAdded);
        }

        public IDataResult<Supplier> GetById(int supplierId)
        {
            return new SuccessDataResult<Supplier>(_ıSupplierDal.Get(p => p.SupplierID == supplierId));
        }

        public IDataResult<List<Supplier>> GetList()
        {
            return new SuccessDataResult<List<Supplier>>(_ıSupplierDal.GetList().ToList());
        }

        public IResult Update(Supplier supplier)
        {
            _ıSupplierDal.Update(supplier);
            return new SuccessResult(Messages.ShipperUpdated);
        }
    }
}
