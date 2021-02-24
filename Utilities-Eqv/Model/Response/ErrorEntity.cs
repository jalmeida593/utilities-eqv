using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Utilities_Eqv.Model.Response
{
    public class ErrorEntity
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }
    }
}
