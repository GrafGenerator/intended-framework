using System.Threading.Tasks;
using Intended.Abstractions.Dal;
using Intended.Abstractions.Domain;
using Intended.Abstractions.OperationsHandling;
using Intended.DependencyInjection;

namespace Intended.OperationsHandling
{
    internal class HandlingScope : IHandlingScope
    {
        private readonly IDiContainerAccessor _containerAccessor;
        private readonly IDbContextAccessor _contextAccessor;
        private readonly IHandlingScopesStack<HandlingScope> _handlingScopesStack;
        private readonly HandlingScope _parentScope;
        private bool _isCommitted;
        // private readonly TransactionScope _transaction;

        public HandlingScope(IDiContainerAccessor containerAccessor, HandlerIdentity identity)
        {
            Identity = identity;
            _containerAccessor = containerAccessor;
            _contextAccessor = _containerAccessor.GetInstance<IDbContextAccessor>();
            _handlingScopesStack = _containerAccessor.GetInstance<IHandlingScopesStack<HandlingScope>>();

            _parentScope = _handlingScopesStack.GetCurrentScope();
            _handlingScopesStack.EnterScope(this);

            // _transaction = new TransactionScope(TransactionScopeOption.Required,
            //      new TransactionOptions {IsolationLevel = IsolationLevel.Snapshot});
        }

        public HandlerIdentity Identity { get; }

        public IRepository<T> Repo<T>()
            where T : class, IEntity
        {
            return _containerAccessor.GetInstance<IRepository<T>>();
        }

        public async Task Commit()
        {
            await EnsureCommitted();
        }

        public void Dispose()
        {
            // _transaction.Dispose();
        }

        private async Task EnsureCommitted()
        {
            if (_isCommitted) return;

            if (_parentScope == null) // root scope, do real changes commit
                await _contextAccessor.SaveChangesAsync();

            _isCommitted = true;
            _handlingScopesStack.LeaveLastScope();

            // _transaction.Complete();
        }
    }
}