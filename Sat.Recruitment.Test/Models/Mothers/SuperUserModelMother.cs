﻿using System;

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
                Money = rnd.Next(100, 200),
                Type = UserType.SUPERUSER
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
                Type = UserType.SUPERUSER,
                Money = user.Money,
            };
        }

        public static SuperUserModel WithMoney(int money)
        {
            Random rnd = new Random();
            return new SuperUserModel()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = RandomString.Generate(rnd.Next(15)),
                Money = money,
                Type = UserType.SUPERUSER
            };
        }
    }
}
