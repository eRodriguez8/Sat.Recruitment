using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Entities;

namespace Sat.Recruitment.Test.Models.Mothers
{
    public static class SuperUserModelMother
    {
        public static SuperUserModel Random()
        {
            Random rnd = new Random();
            return new SuperUserModel()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = rnd.Next(10),
                Type = UserTypeMother.Random()
            };
        }

        public static SuperUserModel FromDto(UserDto user)
        {
            return new SuperUserModel()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                Type = (UserType)Enum.Parse(typeof(UserType), user.UserType),
                Money = user.Money,
            };
        }
    }
}
