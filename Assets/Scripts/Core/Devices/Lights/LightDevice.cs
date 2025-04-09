using R3;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDevice : Device
    {
        public DeviceInputPort Input { get; }

        private readonly GameObject _lightSource;

        public LightDevice(GameObject lightSource)
        {
            _lightSource = lightSource;

            Input = new();

            Input.IsPowered
                .Subscribe(OnInputPowered);
        }

        private void OnInputPowered(bool isPowered)
        {
            _lightSource.SetActive(isPowered);
        }
    }
}
