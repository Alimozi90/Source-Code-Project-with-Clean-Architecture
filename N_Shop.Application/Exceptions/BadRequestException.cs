using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Shop.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string messge) : base(messge)
        {

        }
    }
}
