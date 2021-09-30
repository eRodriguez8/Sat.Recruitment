using System;

namespace Sat.Recruitment.Models.Exceptions
{
    [Serializable]
    public class DuplicatedUserException : Exception
    {
        public DuplicatedUserException()
        {
        }

        public DuplicatedUserException(string message) : base(message)
        {
        }

        public DuplicatedUserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
