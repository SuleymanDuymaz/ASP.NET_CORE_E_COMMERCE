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
    public class TerritoryManager : ITerritoryService
    {
        ITerritoryDal _ıTerritoryDal;
        public TerritoryManager(ITerritoryDal ıTerritoryDal)
        {
            _ıTerritoryDal = ıTerritoryDal;
        }
        public IResult Add(Territory territory)
        {
            _ıTerritoryDal.Add(territory);
            return new SuccessResult(Messages.TerritoryAdded);
        }

        public IResult Delete(Territory territory)
        {
            _ıTerritoryDal.Delete(territory);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Territory> GetById(string territoryId)
        {
            return new SuccessDataResult<Territory>(_ıTerritoryDal.Get(p => p.TerritoryID == territoryId));
        }

        public IDataResult<List<Territory>> GetList()
        {
            return new SuccessDataResult<List<Territory>>(_ıTerritoryDal.GetList().ToList());
        }

        public IResult Update(Territory territory)
        {

            _ıTerritoryDal.Update(territory);
            return new SuccessResult(Messages.TerritoryUpdated);
        }
    }
}
