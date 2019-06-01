using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Intended.OperationsHandling
{
    internal class HandlingScopesStack : IHandlingScopesStack<HandlingScope>
    {
        private readonly Stack<HandlingScope> _scopes = new Stack<HandlingScope>();

        public void EnterScope(HandlingScope scope)
        {
            _scopes.Push(scope);
        }

        public HandlingScope LeaveLastScope()
        {
            return _scopes.Any() ? _scopes.Pop() : null;
        }

        public HandlingScope GetCurrentScope()
        {
            return _scopes.Any() ? _scopes.Peek() : null;
        }

        public IEnumerator<HandlingScope> GetEnumerator()
        {
            return _scopes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal interface IHandlingScopesStack<T>: IEnumerable<T>
        where T : HandlingScope
    {
        void EnterScope(T scope);
        T LeaveLastScope();
        T GetCurrentScope();
    }
}