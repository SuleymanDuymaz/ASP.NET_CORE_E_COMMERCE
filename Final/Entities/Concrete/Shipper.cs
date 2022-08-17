using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Shipper:IEntity
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
    }
}
