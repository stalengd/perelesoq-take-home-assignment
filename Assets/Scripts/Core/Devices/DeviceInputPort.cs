using R3;

namespace Perelesoq.TestAssignment.Core.Devices
{
    public sealed class DeviceInputPort
    {
        public ReactiveProperty<float> RequiredPower { get; } = new(0f);
        public ReactiveProperty<float> PowerUsage { get; } = new(0f);
        public ReactiveProperty<DeviceOutputPort> Connection { get; } = new(null);
        public ReactiveProperty<bool> IsPowered { get; } = new(false);

        public DeviceInputPort()
        {

        }

        public DeviceInputPort(float powerUsage)
        {
            RequiredPower.Value = powerUsage;
        }
    }
}
