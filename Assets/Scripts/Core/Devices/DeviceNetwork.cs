using ObservableCollections;
using Perelesoq.TestAssignment.Core.Devices.PowerSources;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices
{
    public sealed class DeviceNetwork
    {
        public PowerSourceDevice PowerSource { get; private set; }
        public IObservableCollection<Device> Devices => _devices;

        private readonly ObservableHashSet<Device> _devices = new();

        public void AddDevice(Device device)
        {
            device.Network = this;
            _devices.Add(device);

            if (device is PowerSourceDevice powerSource)
            {
                if (PowerSource == null)
                {
                    PowerSource = powerSource;
                }
                else
                {
                    Debug.LogError("Tried to add second power source to the network, this is not supported");
                }
            }
        }

        public void Connect(DeviceOutputPort portA, DeviceInputPort portB)
        {
            portA.Connections.Add(portB);
            portB.Connection.Value = portA;
        }

        public void SetOutputActive(DeviceOutputPort port, bool isActive)
        {
            port.IsActive.Value = isActive;
            foreach (var connection in port.Connections)
            {
                RecalculateInputPowered(connection);
            }
        }

        public void SetOutputPowered(DeviceOutputPort port, bool isPowered)
        {
            port.IsPowered.Value = isPowered;
            foreach (var connection in port.Connections)
            {
                RecalculateInputPowered(connection);
            }
        }

        public void SetInputPowerRequirement(DeviceInputPort port, float requiredPower)
        {
            port.RequiredPower.Value = requiredPower;
            RecalculateInputPowered(port);
        }

        private void RecalculateInputPowered(DeviceInputPort port)
        {
            var connectedOutput = port.Connection.Value;
            var shouldBePowered = connectedOutput is { }
                && connectedOutput.IsPowered.Value
                && connectedOutput.IsActive.Value;

            var totalPowerUsage = PowerSource.PowerUsage.Value;
            totalPowerUsage -= port.PowerUsage.Value;

            var portPowerUsage = port.RequiredPower.Value * (shouldBePowered ? 1 : 0);
            if (shouldBePowered && portPowerUsage + totalPowerUsage > PowerSource.MaxPower)
            {
                shouldBePowered = false;
            }

            portPowerUsage *= shouldBePowered ? 1 : 0;
            totalPowerUsage += port.PowerUsage.Value;

            port.PowerUsage.Value = portPowerUsage;
            if (totalPowerUsage != PowerSource.PowerUsage.Value)
            {
                PowerSource.PowerUsage.Value = totalPowerUsage;
            }

            if (shouldBePowered == port.IsPowered.Value)
            {
                return;
            }

            port.IsPowered.Value = shouldBePowered;
        }
    }
}
