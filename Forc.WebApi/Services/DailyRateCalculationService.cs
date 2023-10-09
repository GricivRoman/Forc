using Forc.Infrastructure.Models;
using Forc.WebApi.Interfaces;

namespace Forc.WebApi.Services
{
    public class DailyRateCalculationService : IDailyRateCalculationService
    {
        public DailyRate CalculateDailyRate(UserTarget userTarget)
        {
            // TODO реализация расчета 
            var rate = new DailyRate()
            {
                Id= userTarget.Id,
                CaloriesRate = 2000,
                FatRate = 75,
                CarbohydrateRate = 210,
                ProteinRate = 90
            };

            return rate;
        }
    }
}
