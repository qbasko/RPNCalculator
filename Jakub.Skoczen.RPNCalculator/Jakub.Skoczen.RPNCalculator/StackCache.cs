using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakub.Skoczen.RPNCalculator
{
    class StackCache
    {
        private Stack<StackElement> _cache;

        public StackCache(Stack<StackElement> cache)
        {
            Stack<StackElement> stack = new Stack<StackElement>();
            List<StackElement> elements = cache.ToList();
            foreach (StackElement e in elements)
                stack.Push(e);           
            _cache = stack;            
        }

        public StackCache()
        {
        }

        public Stack<StackElement> GetCache()
        {
            return _cache;
        }
    }
}
