using LiverAR.Core.Domain;
using LiverAR.Modules.HealthLogic.Runtime.Domain;

namespace LiverAR.Modules.HealthLogic.Runtime.UseCases
{
    public sealed class AssessRiskUseCase
    {
        public (RiskLevel level, string message) Execute(SymptomReport report)
        {
            if (report == null)
            {
                return (RiskLevel.Low, "Semptom bilgisi bulunamadi.");
            }

            if (report.TemperatureCelsius >= 38.0f || report.HasWoundRedness)
            {
                return (RiskLevel.High, "Yuksek risk belirtisi var. Lutfen transplant ekibinizle iletisime gecin.");
            }

            if (report.HasSeverePain || report.HasNausea || report.EnergyLevel <= 2)
            {
                return (RiskLevel.Medium, "Orta risk belirtisi var. Semptomlari yakindan takip edin.");
            }

            return (RiskLevel.Low, "Acil risk sinyali gorunmuyor. Gunluk takibe devam edin.");
        }
    }
}
