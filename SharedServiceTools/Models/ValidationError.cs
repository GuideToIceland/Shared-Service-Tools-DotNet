using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ValidationError
    {
        public ValidationError()
        {
            this.Message = "OK";
        }

        public ValidationError(string source, string message)
        {
            this.Source = source;
            this.Message = message;
        }

        public string Source { get; set; }

        public string Message { get; set; }
    }
}
