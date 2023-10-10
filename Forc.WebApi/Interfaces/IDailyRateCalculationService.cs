using Forc.Infrastructure.Models;

namespace Forc.WebApi.Interfaces
{
    public interface IDailyRateCalculationService
    {
        DailyRate CalculateDailyRate(UserTarget userTarget);
    }
}
