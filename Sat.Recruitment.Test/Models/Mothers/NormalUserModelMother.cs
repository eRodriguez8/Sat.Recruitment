using System;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Enums;
using Sat.Recruitment.Models.Entities;

namespace Sat.Recruitment.Test.Models.Mothers
{
    public static class NormalUserModelMother
    {
        public static NormalUserModel Random()
        {
            Random rnd = new Random();
            return new NormalUserModel()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = rnd.Next(10),
                Type = UserTypeMother.Random()
            };
        }

        public static NormalUserModel FromDto(UserDto user)
        {
            return new NormalUserModel()
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
