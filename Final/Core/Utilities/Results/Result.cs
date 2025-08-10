using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //burada get ile tanımlanmış alanlar readonl olarak işlem görür. Ancak construcyor metod içerisinde set edilebilme özelliğine sahiptir.
        public bool Success { get; }

        public string Message { get; }

        public Result(bool success, string message):this(success) //tek paramerreli olan çalışır
        {
           
           Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

       

    }
}
