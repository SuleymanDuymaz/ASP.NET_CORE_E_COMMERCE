using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITerritoryService
    {
        IDataResult<Territory> GetById(string territoryId);
        IDataResult<List<Territory>> GetList();
        IResult Add(Territory territory);
        IResult Delete(Territory territory);
        IResult Update(Territory territory);

    }
}
