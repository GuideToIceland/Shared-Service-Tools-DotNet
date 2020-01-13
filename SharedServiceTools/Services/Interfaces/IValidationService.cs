using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public interface IValidatorService
    {
        ValidationResult Validate<TApplicationParameters>(TApplicationParameters data);
    }
}
