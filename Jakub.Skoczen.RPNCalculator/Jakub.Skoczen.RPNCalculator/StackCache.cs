using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator
{
    class StackCache<T>
    {
        private T _cache;

        public StackCache(T cache)
        {
            _cache = cache;
        }

        public StackCache()
        {
        }

        public T GetCache()
        {
            return _cache;
        }
    }
}
