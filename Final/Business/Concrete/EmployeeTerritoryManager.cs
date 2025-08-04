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
    public class EmployeeTerritoryManager : IEmployeeTerritoryService
    {
        IEmployeeTerritoryDal _ıEmployeeTerritoryDal;
        public EmployeeTerritoryManager(IEmployeeTerritoryDal employeeTerritoryDal)
        {
            _ıEmployeeTerritoryDal = employeeTerritoryDal;
        }
        public IDataResult<List<EmployeeTerritory>> GetListByEmployeeId(int employeeId)
        {
            return new SuccessDataResult<List<EmployeeTerritory>>(_ıEmployeeTerritoryDal.GetList(p => p.EmployeeID == employeeId).ToList());
        }
    }
}
