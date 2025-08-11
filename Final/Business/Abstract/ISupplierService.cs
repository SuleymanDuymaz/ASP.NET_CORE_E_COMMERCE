using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<List<Supplier>> GetList();
        IDataResult<Supplier> GetById(int supplierId);
        IResult Update(Supplier supplier);
        IResult Add(Supplier supplier);
    }
}
