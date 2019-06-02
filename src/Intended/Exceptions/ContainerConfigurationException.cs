using System;

namespace Intended.Exceptions
{
    public class ContainerConfigurationException: Exception
    {
        public ContainerConfigurationException(string message): base(message)
        {
        }
    }
}