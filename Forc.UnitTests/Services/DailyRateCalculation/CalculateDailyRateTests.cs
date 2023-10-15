using Forc.Infrastructure.Enums;
using Forc.Infrastructure.Models;
using Forc.WebApi.Services;
using Moq;

namespace Forc.UnitTests.Services.DailyRateCalculation
{
    public class CalculateDailyRateTests
    {
        [Fact]
        public void CalculateDailyRate_TargetWithoutUser_ReturnError()
        {
            var userTarget = new Mock<UserTarget>().Object;
            var dailyRateCalculationService = new DailyRateCalculationService();
            Action act = () => dailyRateCalculationService.CalculateDailyRate(userTarget);

            NullReferenceException exception = Assert.Throws<NullReferenceException>(act);
            Assert.Equal("User can't be null", exception.Message);
        }

        [Fact]
        public void CalculateDailyRate_TargetWithoutHeight_ReturnError()
        {
            var user = new Mock<User>().Object;
            user.Sex = SexEnum.Male;
            user.BirthDate = new DateTime(2000, 11, 12);

            var userTarget = new Mock<UserTarget>().Object;
            userTarget.User = user;

            var dailyRateCalculationService = new DailyRateCalculationService();
            Action act = () => dailyRateCalculationService.CalculateDailyRate(userTarget);

            ApplicationException exception = Assert.Throws<ApplicationException>(act);
            Assert.Equal("Can't count your daily rate without your height", exception.Message);

        }

        [Fact]
        public void CalculateDailyRate_TargetWithoutSex_ReturnError()
        {
            var user = new Mock<User>().Object;
            user.BirthDate = new DateTime(2000, 11, 12);
            user.Height = 172;

            var userTarget = new Mock<UserTarget>().Object;
            userTarget.User = user;

            var dailyRateCalculationService = new DailyRateCalculationService();
            Action act = () => dailyRateCalculationService.CalculateDailyRate(userTarget);

            ApplicationException exception = Assert.Throws<ApplicationException>(act);
            Assert.Equal("Can't count your daily rate without your sex", exception.Message);

        }

        [Fact]
        public void CalculateDailyRate_TargetWithoutAge_ReturnError()
        {
            var user = new Mock<User>().Object;
            user.Height = 172;
            user.Sex = SexEnum.Male;

            var userTarget = new Mock<UserTarget>().Object;
            userTarget.User = user;

            var dailyRateCalculationService = new DailyRateCalculationService();
            Action act = () => dailyRateCalculationService.CalculateDailyRate(userTarget);

            ApplicationException exception = Assert.Throws<ApplicationException>(act);
            Assert.Equal("Can't count your daily rate without your age", exception.Message);
        }

        public static IEnumerable<object[]> CalculateDailyRateData =>
           new List<object[]>
           {
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 90, 80, 1, 1839.5, 109.5, 90, 135 },
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 90, 80, 1.25, 2306.5, 223.5, 90, 135 },
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 90, 80, 1.5, 2773, 337, 90, 135 },
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 80, 90, 1, 1778, 94, 88, 140 },
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 80, 90, 1.25, 2219.5, 201.5, 88, 140 },
                new object[] { SexEnum.Male, new DateTime(2000, 11, 12), 172, 80, 90, 1.5, 2661, 309.5, 88, 140 },
                new object[] { SexEnum.Male, new DateTime(1975, 11, 12), 172, 80, 90, 1.25, 2065.5, 164, 88, 140 },
                new object[] { SexEnum.Male, new DateTime(1975, 11, 12), 172, 90, 80, 1.25, 2152.5, 186, 90, 135 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 70, 60, 1, 1449, 20.5, 105, 94.5 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 70, 60, 1.25, 1818, 110.5, 105, 94.5 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 70, 60, 1.5, 2186.5, 200.5, 105, 94.5 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 50, 60, 1, 1287.5, 43.5, 80, 89 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 50, 60, 1.25, 1606, 121, 80, 89 },
                new object[] { SexEnum.Female, new DateTime(2000, 11, 12), 168, 50, 60, 1.5, 1925, 199, 80, 89 },
                new object[] { SexEnum.Female, new DateTime(1975, 11, 12), 168, 70, 60, 1.25, 1664, 73, 105, 94.5 },
                new object[] { SexEnum.Female, new DateTime(1975, 11, 12), 168, 50, 60, 1.25, 1452.5, 9.5, 102, 113.5 },
           };

        [Theory]
        [MemberData(nameof(CalculateDailyRateData))]
        public void CalculateDailyRate_ReturnCorrectRate(
            SexEnum sex,
            DateTime birthDate,
            double height,
            double currentBodyWeight,
            double targetBodyWeight,
            double physicalActivityMultiplier,
            double expectedCaloriesRate,
            double expectedCarbohydrateRate,
            double expectedFatRate,
            double expectedProteinRate)
        {
            var user = new Mock<User>().Object;
            user.BirthDate = birthDate;
            user.Height = height;
            user.Sex = sex;

            var userTarget = new Mock<UserTarget>().Object;
            userTarget.User = user;

            userTarget.DateStart = new DateTime(2022, 05, 20);
            userTarget.DateFinish = new DateTime(2022, 08, 20);

            userTarget.CurrentBodyWeight = currentBodyWeight;
            userTarget.TargetBodyWeight = targetBodyWeight;

            var physicalActivity = new Mock<PhysicalActivity>().Object;
            physicalActivity.PhysicalActivityMultiplier = physicalActivityMultiplier;

            userTarget.User.PhysicalActivity = physicalActivity;

            var dailyRateCalculationService = new DailyRateCalculationService();
            var response = dailyRateCalculationService.CalculateDailyRate(userTarget);

            Assert.Multiple(() =>
            {
                Assert.Equal(expectedCaloriesRate, response.CaloriesRate);
                Assert.Equal(expectedCarbohydrateRate, response.CarbohydrateRate);
                Assert.Equal(expectedFatRate, response.FatRate);
                Assert.Equal(expectedProteinRate, response.ProteinRate);
            });
        }
    }
}
