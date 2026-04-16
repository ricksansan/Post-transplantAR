using UnityEngine;

namespace LiverAR.Bootstrap
{
    public sealed class SceneBootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 0;
        }
    }
}
