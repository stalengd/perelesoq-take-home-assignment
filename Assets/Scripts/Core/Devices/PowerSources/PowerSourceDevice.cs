using System;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDevice : Device
    {
        public DeviceOutputPort Output { get; }
        public float MaxPower { get; } // Watt (W)
        public ReactiveProperty<float> PowerUsage { get; } = new(0); // Watt (W)
        public float EnergyConsumed { get; private set; } // Watt-seconds (Ws)
        public TimeSpan Uptime { get; private set; }

        public PowerSourceDevice(float maxPower)
        {
            MaxPower = maxPower;

            Output = new();
        }

        public override void Update(TimeSpan deltaTime)
        {
            if (!Output.IsActive.Value)
            {
                return;
            }
            Uptime += deltaTime;
            EnergyConsumed += (float)(PowerUsage.Value * deltaTime.TotalSeconds);
        }
    }
}
