using Sat.Recruitment.Models.Enums;

namespace Sat.Recruitment.Models.Abstract
{
    public abstract class UserModel
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }
        public UserType Type { get; protected set; }
        public decimal Money { get; protected set; }

        public abstract void CalculateMoney();
    }
}
