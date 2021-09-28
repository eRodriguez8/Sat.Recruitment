using Sat.Recruitment.Models;

namespace Sat.Recruitment.Business
{
    public static class ValidateErrors
    {
        public static ErrorModel ValidateUserProps(string name, string email, string address, string phone)
        {
            ErrorModel error = new ErrorModel();

            if (string.IsNullOrEmpty(name))
                error.ErrorList.Add("The name is required");
            if (string.IsNullOrEmpty(email))
                error.ErrorList.Add(" The email is required");
            if (string.IsNullOrEmpty(address))
                error.ErrorList.Add(" The address is required");
            if (string.IsNullOrEmpty(phone))
                error.ErrorList.Add("The phone is required");
            
            return error;
        }
    }
}
