using System.Collections.Generic;
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
        private readonly HashSet<DeviceInputPort> _hungryPorts = new();
        private readonly List<DeviceInputPort> _inputPortBuffer = new();
        private bool _isDistributing;

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
            var wantsBePowered = connectedOutput is { }
                && connectedOutput.IsPowered.Value
                && connectedOutput.IsActive.Value;
            var shouldBePowered = wantsBePowered;

            var totalPowerUsage = PowerSource.PowerUsage.Value;
            totalPowerUsage -= port.PowerUsage.Value;

            var portPowerUsage = port.RequiredPower.Value * (shouldBePowered ? 1 : 0);
            if (shouldBePowered && portPowerUsage + totalPowerUsage > PowerSource.MaxPower)
            {
                shouldBePowered = false;
            }

            if (wantsBePowered && !shouldBePowered)
            {
                _hungryPorts.Add(port);
            }
            else
            {
                _hungryPorts.Remove(port);
            }

            portPowerUsage *= shouldBePowered ? 1 : 0;
            totalPowerUsage += portPowerUsage;

            port.PowerUsage.Value = portPowerUsage;
            if (totalPowerUsage != PowerSource.PowerUsage.Value)
            {
                var isLessUsage = totalPowerUsage < PowerSource.PowerUsage.Value;
                PowerSource.PowerUsage.Value = totalPowerUsage;
                if (isLessUsage)
                {
                    DistributePowerToHungry();
                }
            }

            if (shouldBePowered == port.IsPowered.Value)
            {
                return;
            }

            port.IsPowered.Value = shouldBePowered;
        }

        private void DistributePowerToHungry()
        {
            if (_hungryPorts.Count == 0 || _isDistributing)
            {
                return;
            }
            _isDistributing = true;
            _inputPortBuffer.Clear();

            _inputPortBuffer.AddRange(_hungryPorts);
            foreach (var port in _inputPortBuffer)
            {
                RecalculateInputPowered(port);
            }

            _isDistributing = false;
        }
    }
}
