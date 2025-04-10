using Perelesoq.TestAssignment.Core.DeviceInitializers;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [Space]
        [SerializeField] private GameObject _gameView;

        public override Device Initialize()
        {
            var device = new LightDevice(_gameView);
            BindPort(device.Input, _inputPort);
            return device;
        }
    }
}
