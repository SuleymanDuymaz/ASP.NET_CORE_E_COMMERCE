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
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _ıEmployeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _ıEmployeeDal = employeeDal;
        }

        public IResult Add(Employee employee)
        {
            _ıEmployeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeeAdded);
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_ıEmployeeDal.Get(p => p.EmployeeId == employeeId));
        }

        public IDataResult<List<Employee>> GetList()
        {
            return new SuccessDataResult<List<Employee>>(_ıEmployeeDal.GetList().ToList());
        }

        public IResult Update(Employee employee)
        {
            _ıEmployeeDal.Update(employee);
            return new SuccessResult(Messages.EmployeeUpdated);
        }
    }
}
