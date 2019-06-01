namespace Intended.Abstractions.OperationsHandling
{
    public class HandlerIdentity
    {
        public HandlerIdentity(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; }
        public string Description { get; }

        protected bool Equals(HandlerIdentity other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((HandlerIdentity) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}