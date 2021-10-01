using System;

using Sat.Recruitment.Models.Dtos;

namespace Sat.Recruitment.Test.Models.Mothers
{
    public static class UserDtoMother
    {
        public static UserDto Random()
        {
            Random rnd = new Random();
            return new UserDto()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = rnd.Next(15).ToString(),
                Money = rnd.Next(10),
                UserType = UserTypeMother.Random().ToString()
            };
        }

        public static UserDto WithType(string type)
        {
            Random rnd = new Random();
            return new UserDto()
            {
                Name = RandomString.Generate(rnd.Next(10)),
                Email = RandomString.Generate(rnd.Next(15)) + "@mail.com",
                Address = RandomString.Generate(rnd.Next(20)),
                Phone = rnd.Next(15).ToString(),
                Money = rnd.Next(10),
                UserType = type
            };
        }
    }
}
