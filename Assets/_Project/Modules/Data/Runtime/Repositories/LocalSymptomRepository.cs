using System;
using UnityEngine;
using LiverAR.Modules.HealthLogic.Runtime.Domain;

namespace LiverAR.Modules.Data.Runtime.Repositories
{
    public sealed class LocalSymptomRepository
    {
        private const string LastSymptomKey = "liverar.last.symptom.report";

        [Serializable]
        private sealed class Wrapper
        {
            public SymptomReport Report;
        }

        public void Save(SymptomReport report)
        {
            var wrapper = new Wrapper { Report = report };
            var json = JsonUtility.ToJson(wrapper);
            PlayerPrefs.SetString(LastSymptomKey, json);
            PlayerPrefs.Save();
        }

        public SymptomReport LoadLast()
        {
            if (!PlayerPrefs.HasKey(LastSymptomKey))
            {
                return null;
            }

            var json = PlayerPrefs.GetString(LastSymptomKey, string.Empty);
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            var wrapper = JsonUtility.FromJson<Wrapper>(json);
            return wrapper?.Report;
        }
    }
}
