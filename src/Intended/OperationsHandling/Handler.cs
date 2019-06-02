namespace Intended.OperationsHandling
{
    public static class Handler
    {
        public static HandlerIdentity Identity(int id, string description = "{ no handler desctiption provided }")
        {
            return new HandlerIdentity(id, description);
        }
    }
}