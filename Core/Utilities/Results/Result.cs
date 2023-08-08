using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
    
        //this =means use the succes work both work them...

        public Result(bool succes, string message):this(succes)
        {
            Message = message;
           

        }
        //we are doing the overloading... to use both method we dont want to message like that.
        public Result(bool succes)
        {
            Success = succes;

        }

        public bool Success { get; }

        public string Message { get; }

    }
}
