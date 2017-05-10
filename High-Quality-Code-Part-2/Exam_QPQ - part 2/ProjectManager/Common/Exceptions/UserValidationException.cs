using System;

namespace ProjectManager.Common.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(" - Error: " + message)
        {
        }
    }
}
