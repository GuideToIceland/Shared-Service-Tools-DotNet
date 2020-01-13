using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools.Models
{
    public class ErrorInfo
    {
        public ErrorInfo(IEnumerable<ErrorMessage> errors)
        {
            this.Errors = errors;
        }

        public IEnumerable<ErrorMessage> Errors { get; set; }
    }
}
