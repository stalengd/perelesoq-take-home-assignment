using Perelesoq.TestAssignment.Core.DeviceInitializers;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceOutputPortInitializer _outputPort;
        [Space]
        [SerializeField] private float _maxPower = 1200;

        public override Device Initialize(DeviceNetwork network)
        {
            PowerSourceDevice device = new(_maxPower);
            network.AddDevice(device);
            network.PowerSource = device;
            BindPort(device.Output, _outputPort);
            return device;
        }
    }
}
