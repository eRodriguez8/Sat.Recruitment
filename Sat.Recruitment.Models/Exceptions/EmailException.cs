using System;

namespace Sat.Recruitment.Models.Exceptions
{
    [Serializable]
    public class EmailException : Exception
    {
        public EmailException()
        {
        }

        public EmailException(string message) : base(message)
        {
        }

        public EmailException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
