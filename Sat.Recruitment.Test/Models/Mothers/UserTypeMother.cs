using System;

using Sat.Recruitment.Models.Enums;

namespace Sat.Recruitment.Test.Models.Mothers
{
    public static class UserTypeMother
    {
        public static UserType Random()
        {
            Array values = Enum.GetValues(typeof(UserType));
            Random random = new Random();
            return (UserType)values.GetValue(random.Next(values.Length));
        }
    }
}
