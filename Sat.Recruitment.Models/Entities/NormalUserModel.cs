using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Models.Entities
{
    public class NormalUserModel : UserModel
    {
        public NormalUserModel() { }

        public NormalUserModel(UserDto user)
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
            if (Money > 100)
                Money += Money * Convert.ToDecimal(0.12);
            else if (Money < 100 && Money > 10)
                Money += Money * Convert.ToDecimal(0.8);
        }
    }
}
