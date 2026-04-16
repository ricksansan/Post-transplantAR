using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace LiverAR.Modules.AR.Runtime.Controllers
{
    public sealed class ARPlacementController : MonoBehaviour
    {
        [SerializeField] private ARRaycastManager raycastManager;
        [SerializeField] private GameObject liverPrefab;
        [SerializeField] private Camera arCamera;

        private static readonly List<ARRaycastHit> Hits = new();
        private GameObject _spawnedObject;

        public bool TryPlaceFromScreenTap(Vector2 screenPosition)
        {
            if (raycastManager == null || liverPrefab == null)
            {
                return false;
            }

            if (!raycastManager.Raycast(screenPosition, Hits, TrackableType.PlaneWithinPolygon))
            {
                return false;
            }

            var hitPose = Hits[0].pose;

            if (_spawnedObject == null)
            {
                _spawnedObject = Instantiate(liverPrefab, hitPose.position, hitPose.rotation);
            }
            else
            {
                _spawnedObject.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
            }

            return true;
        }
    }
}
