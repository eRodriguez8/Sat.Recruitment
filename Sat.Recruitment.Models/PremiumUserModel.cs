using System;

using Sat.Recruitment.Models.DTOs;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Models
{
    public class PremiumUserModel : UserModel
    {
        public PremiumUserModel(UserDTO user)
        {
            Name = user.Name;
            Email = user.Email;
            Address = user.Address;
            Phone = user.Phone;
            Money = user.Money;
            Type = (UserType)Enum.Parse(typeof(UserType), user.UserType);
            CalculateMoney();
        }

        public override void CalculateMoney()
        {
            if(Money > 100)
                Money += Money * 2;
        }
    }
}
