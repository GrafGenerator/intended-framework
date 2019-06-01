using System;
using Intended.Abstractions.Domain;
using Intended.Abstractions.OperationsHandling;

namespace Intended.OperationsHandling
{
    internal class UnixTimeEntityIdentityService : IEntityIdentityService
    {
        private static readonly object LockObject = new object();
        private static long _lastGeneratedIdentity = -1;
        private static readonly DateTime BaseDate = DateTime.SpecifyKind(new DateTime(2018, 1, 1, 0, 0, 0), DateTimeKind.Utc);

        public void SetId(IEntity entity)
        {
            lock (LockObject)
            {
                var generatedIdentity = GetTicks(DateTime.UtcNow);

                if (_lastGeneratedIdentity == -1)
                {
                    _lastGeneratedIdentity = generatedIdentity;
                }

                if (generatedIdentity <= _lastGeneratedIdentity)
                {
                    generatedIdentity = _lastGeneratedIdentity + 1;
                }

                entity.Id = generatedIdentity;

                _lastGeneratedIdentity = generatedIdentity;
            }
        }

        private long GetTicks(DateTime time)
        {
            return time.Ticks - BaseDate.Ticks;
        }
    }
}