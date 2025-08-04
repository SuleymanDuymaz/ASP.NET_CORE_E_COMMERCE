using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class EmployeeTerritory : IEntity
    {
        [Key]
        public int EmployeeID { get; set; }
        public string TerritoryID { get; set; }

    }
}
