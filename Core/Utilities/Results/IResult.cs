using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //base of void for starting...
    public interface IResult
    {
        //we just read the informations... it is succes if correct true 1 or false  0
        bool Success { get; }
        string Message { get; }


    }
}
