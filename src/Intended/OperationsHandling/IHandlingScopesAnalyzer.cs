using System.Collections.Generic;

namespace Intended.OperationsHandling
{
    public interface IHandlingScopesAnalyzer
    {
        IHandlingScopesAnalyzerIdentityAssertion Identity(HandlerIdentity identity);
        IHandlingScopesAnalyzerIdentitiesAssertion Identities(IEnumerable<HandlerIdentity> identities);
    }

    public interface IHandlingScopesAnalyzerIdentitiesAssertion
    {
        bool MatchRootOperation();
    }

    public interface IHandlingScopesAnalyzerIdentityAssertion
    {
        bool IsRootOperation();
        bool IsOperationInHierarchy();
    }
}