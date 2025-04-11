using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceGameView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _lightSources;

        public void SetEmittingLight(bool isEmitting)
        {
            foreach (var source in _lightSources)
            {
                source.SetActive(isEmitting);
            }
        }
    }
}

