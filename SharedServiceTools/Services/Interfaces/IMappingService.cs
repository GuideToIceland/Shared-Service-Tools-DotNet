using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServiceTools
{
    public interface IMappingService
    {
        TResult Map<TResult>(object source);

        TResult Map<TSource, TResult>(TSource source);

        TResult Map<TResult>(object source, Action<TResult> afterMap);

        TResult Merge<TResult>(params object[] sources);
    }
}
