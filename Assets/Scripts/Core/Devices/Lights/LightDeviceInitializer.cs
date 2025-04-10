using Perelesoq.TestAssignment.Core.DeviceInitializers;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [SerializeField] private GameObject _gameView;
        [Space]
        [SerializeField] private float _powerUsage = 100f;

        public override Device Initialize()
        {
            var device = new LightDevice(_powerUsage, _gameView);
            BindPort(device.Input, _inputPort);
            return device;
        }
    }
}
