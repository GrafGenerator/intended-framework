namespace Intended.OperationsHandling.GenericResults
{
    public class MessageResult: OperationResult
    {
        public string Message { get; }

        public MessageResult(string message)
        {
            Message = message;
        }
    }

    public static class Messaged
    {
        public static MessageResult Result(string message)
        {
            return new MessageResult(message).IsOk();
        }
    }
}