using Xunit;
using System;

using Sat.Recruitment.Test.Models.Mothers;

namespace Sat.Recruitment.Test.Models.User.CalculateMoney
{
    public class CalculateMoneyTest
    {
        [Theory]
        [InlineData(101, 113.12)]
        [InlineData(200, 224)]
        [InlineData(300, 336)]
        public void GivenANormalUserWithMoreMoneyThan100_WhenCalculateMoneyIsCall_ShouldBeTwelvePercentMore(int actual, decimal expected)
        {
            var user = NormalUserModelMother.WithMoney(actual);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(11, 19.8)]
        [InlineData(20, 36)]
        [InlineData(50, 90)]
        public void GivenANormalUserWithMoneyBetween10And100_WhenCalculateMoneyIsCall_ShouldBeEightPercentMore(int actual, decimal expected)
        {
            var user = NormalUserModelMother.WithMoney(actual);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public void GivenANormalUserWithLessMoneyThan10_WhenCalculateMoneyIsCall_ShouldBeTheSame(int expected)
        {
            var user = NormalUserModelMother.WithMoney(expected);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(101, 121.2)]
        [InlineData(200, 240)]
        [InlineData(300, 360)]
        public void GivenASuperUserWithMoreMoneyThan100_WhenCalculateMoneyIsCall_ShouldBeTwentyPercentMore(int actual, decimal expected)
        {
            var user = SuperUserModelMother.WithMoney(actual);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void GivenASuperUserWithLessOrEqualMoneyThan100_WhenCalculateMoneyIsCall_ShouldBeTheSame(int expected)
        {
            var user = SuperUserModelMother.WithMoney(expected);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(200, 600)]
        [InlineData(300, 900)]
        public void GivenAPremiumUserWithMoreMoneyThan100_WhenCalculateMoneyIsCall_ShouldBeTriplicate(int actual, decimal expected)
        {
            var user = PremiumUserModelMother.WithMoney(actual);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void GivenAPremiumUserWithLessOrEqualMoneyThan100_WhenCalculateMoneyIsCall_ShouldBeTheSame(int expected)
        {
            var user = PremiumUserModelMother.WithMoney(expected);

            user.CalculateMoney();

            Assert.Equal(expected, user.Money);
        }
    }
}
