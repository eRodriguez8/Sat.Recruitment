using System;
using System.Collections.Generic;

using Sat.Recruitment.Models.Dtos;
using Sat.Recruitment.Models.Abstract;

namespace Sat.Recruitment.Business.Helpers
{
    public static class HasUser
    {
        public static bool Duplicated(List<UserModel> users, UserDto user)
        {
            return users.Exists(existentUser =>
            {
                return (
                    (String.Equals(existentUser.Email, user.Email) || String.Equals(existentUser.Phone, user.Phone)) ||
                        (String.Equals(existentUser.Name, user.Name) && String.Equals(existentUser.Address, user.Address))
                );
            });
        }
    }
}
