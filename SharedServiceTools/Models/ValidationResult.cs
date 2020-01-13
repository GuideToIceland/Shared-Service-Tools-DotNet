using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public class ValidationResult
    {
        public ValidationResult(ErrorMessage error, bool isValid)
        {
            this.Error = error;
            this.IsValid = isValid;
        }

        public ErrorMessage Error { get; set; }

        public bool IsValid { get; set; }
    }
}
