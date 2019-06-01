using System.Collections.Generic;
using System.Linq;
using Intended.Abstractions.OperationsHandling;

namespace Intended.OperationsHandling
{
    internal class HandlingScopesAnalyzer: IHandlingScopesAnalyzer
    {
        private readonly IHandlingScopesStack<HandlingScope> _scopesStack;

        public HandlingScopesAnalyzer(IHandlingScopesStack<HandlingScope> scopesStack)
        {
            _scopesStack = scopesStack;
        }

        public IHandlingScopesAnalyzerIdentityAssertion Identity(HandlerIdentity identity)
        {
            return new IdentityAssertion(_scopesStack, identity);
        }

        public IHandlingScopesAnalyzerIdentitiesAssertion Identities(IEnumerable<HandlerIdentity> identities)
        {
            return new IdentitiesAssertion(_scopesStack, identities);
        }

        private class IdentityAssertion: IHandlingScopesAnalyzerIdentityAssertion
        {
            private readonly HandlerIdentity _identityToCheck;
            private readonly HandlerIdentity[] _scopeIdentities;

            public IdentityAssertion(IHandlingScopesStack<HandlingScope> scopesStack, HandlerIdentity identityToCheck)
            {
                _scopeIdentities = scopesStack.Select(s => s.Identity).Reverse().ToArray();
                _identityToCheck = identityToCheck;
            }

            public bool IsRootOperation()
            {
                return _scopeIdentities.Any() && Equals(_scopeIdentities[0], _identityToCheck);
            }

            public bool IsOperationInHierarchy()
            {
                return _scopeIdentities.Any(i => Equals(i, _identityToCheck));
            }
        }

        private class IdentitiesAssertion: IHandlingScopesAnalyzerIdentitiesAssertion
        {
            private readonly IEnumerable<HandlerIdentity> _identitiesToCheck;
            private readonly HandlerIdentity[] _scopeIdentities;

            public IdentitiesAssertion(IHandlingScopesStack<HandlingScope> scopesStack, IEnumerable<HandlerIdentity> identitiesToCheck)
            {
                _scopeIdentities = scopesStack.Select(s => s.Identity).Reverse().ToArray();
                _identitiesToCheck = identitiesToCheck;
            }

            public bool MatchRootOperation()
            {
                return _scopeIdentities.Any() && _identitiesToCheck.Any(i => Equals(_scopeIdentities[0], i));
            }
        }
    }
}