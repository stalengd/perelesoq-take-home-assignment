using Perelesoq.TestAssignment.Core.DeviceInitializers;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [Space]
        [SerializeField] private GameObject _gameView;

        public override Device Initialize(DeviceNetwork network)
        {
            var device = new LightDevice(_gameView);
            network.AddDevice(device);
            BindPort(device.Input, _inputPort);
            return device;
        }
    }
}
