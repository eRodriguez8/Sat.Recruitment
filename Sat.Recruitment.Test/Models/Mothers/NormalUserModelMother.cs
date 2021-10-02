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
                Money = rnd.Next(0, 101),
                Type = UserType.NORMAL
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
                Type = UserType.NORMAL,
                Money = user.Money,
            };
        }

        public static NormalUserModel WithMoney(int money)
        {
            Random rnd = new Random();
            return new NormalUserModel()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = money,
                Type = UserType.NORMAL
            };
        }
    }
}
