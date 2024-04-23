using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class IdParameterBadRequestException : BadRequestException
    {
        public IdParameterBadRequestException()
        :base("Parameter ids is null")
        { }
    }
}
