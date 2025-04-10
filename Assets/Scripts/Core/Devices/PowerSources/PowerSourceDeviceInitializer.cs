using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceOutputPortInitializer _outputPort;
        [SerializeField] private PowerSourceDeviceGameView _gameView;
        [Space]
        [SerializeField] private float _maxPower = 1200;

        public override Device Initialize()
        {
            PowerSourceDevice device = new(_maxPower);
            BindPort(device.Output, _outputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new PowerSourceDevicePresenter(device as PowerSourceDevice, _gameView);
        }
    }
}
