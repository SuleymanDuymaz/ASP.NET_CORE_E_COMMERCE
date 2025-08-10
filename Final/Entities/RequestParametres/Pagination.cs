using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParametres
{
    public record Pagination
    {
        //class record ile de olabilir ancak core 5 ile geldiği için burada geçersiz
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
