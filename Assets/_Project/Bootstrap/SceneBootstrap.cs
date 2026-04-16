using LiverAR.Modules.Data.Runtime.Repositories;
using LiverAR.Modules.HealthLogic.Runtime.Domain;
using LiverAR.Modules.HealthLogic.Runtime.UseCases;
using UnityEngine;

namespace LiverAR.Bootstrap
{
    public sealed class SceneBootstrap : MonoBehaviour
    {
        private AssessRiskUseCase _assessRiskUseCase;
        private LocalSymptomRepository _symptomRepository;

        private void Awake()
        {
            _assessRiskUseCase = new AssessRiskUseCase();
            _symptomRepository = new LocalSymptomRepository();
        }

        public (string level, string message) SaveAndAssess(SymptomReport report)
        {
            _symptomRepository.Save(report);
            var result = _assessRiskUseCase.Execute(report);
            return (result.level.ToString(), result.message);
        }
    }
}
