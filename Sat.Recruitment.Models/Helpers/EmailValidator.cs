using System.Net.Mail;

using Sat.Recruitment.Models.Exceptions;

namespace Sat.Recruitment.Models.Helpers
{
    public static class EmailValidator
    {
        public static void ValidateEmail(string email)
        {
            var addr = new MailAddress(email);
            if(addr.Address != email)
                throw new EmailException("Email format is incorrect");
        }
    }
}
