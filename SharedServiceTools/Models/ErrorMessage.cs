using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
            this.Message = "OK";
        }

        public ErrorMessage(string message, string source)
        {
            this.Source = source;
            this.Message = message;
        }

        public string Source { get; set; }

        public string Message { get; set; }
    }
}
