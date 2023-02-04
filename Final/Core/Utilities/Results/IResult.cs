using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    //temel void işlemleri için kullanılan alan burasıdır. sonuç ve message döner 

    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
