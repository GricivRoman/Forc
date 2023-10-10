using Forc.Infrastructure.Models;
using Forc.WebApi.Interfaces;
using Forc.Functions;

namespace Forc.WebApi.Services
{
    public class DailyRateCalculationService : IDailyRateCalculationService
    {
        public DailyRate CalculateDailyRate(UserTarget userTarget)
        {
            if (userTarget.User.Height == null || userTarget.User.Height == 0)
            {
                throw new ApplicationException("Can't count your daily rate without your height");
            }

            if (userTarget.User.Sex == null)
            {
                throw new ApplicationException("Can't count your daily rate without your sex");
            }

            var calculationUnit = new DailyRateModule.CalculationUnit(
                sex: (DailyRateModule.Sex)userTarget.User.Sex,
                currentBodyWeight: userTarget.CurrentBodyWeight,
                targetBodyWeight: userTarget.TargetBodyWeight,
                height: (double)userTarget.User.Height,
                age: (DateTime.Now - userTarget.User.BirthDate).Value.TotalDays / 365,
                physicalActivityMultiplier: userTarget.User.PhysicalActivity.PhysicalActivityMultiplier,
                daysToRichTarget: (userTarget.DateFinish - userTarget.DateStart).TotalDays);

            var calculatedRate = DailyRateModule.calculateDailyRate(calculationUnit);

            var dailyRate = new DailyRate()
            {
                Id = userTarget.Id,
                CaloriesRate = calculatedRate.CaloriesRate,
                FatRate = calculatedRate.FatRate,
                CarbohydrateRate = calculatedRate.CarbohydrateRate,
                ProteinRate = calculatedRate.ProteinRate
            };

            return dailyRate;
        }
    }
}
