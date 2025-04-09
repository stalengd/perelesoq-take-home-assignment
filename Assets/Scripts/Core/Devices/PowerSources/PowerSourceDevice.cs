using R3;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDevice : Device
    {
        public DeviceOutputPort Output { get; }
        public float MaxPower { get; }
        public ReactiveProperty<float> PowerUsage { get; } = new(0);
        public ReactiveProperty<float> EnergyConsumed { get; } = new(0);

        public PowerSourceDevice(float maxPower)
        {
            MaxPower = maxPower;

            Output = new();
        }
    }
}
