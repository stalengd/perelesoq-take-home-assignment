using System.Collections.Generic;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using Perelesoq.TestAssignment.Core.Devices;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.DeviceInitializers
{
    public abstract class DeviceInitializer : MonoBehaviour
    {
        private readonly List<DeviceInputPortInitializer> _inputPorts = new();
        private readonly List<DeviceOutputPortInitializer> _outputPorts = new();

        public abstract Device Initialize();

        public virtual DevicePresenter InitializePresenter(Device device)
        {
            return null;
        }

        public void InitializeConnections(Device device, DeviceNetwork network)
        {
            foreach (var inputPort in _inputPorts)
            {
                if (inputPort.ConnectedTo != null)
                {
                    network.Connect(inputPort.ConnectedTo.Port, inputPort.Port);
                }
            }
        }

        public void PushDiagnostics(Device device, DeviceNetworkDiagnosticsContainer container)
        {
            foreach (var inputPort in _inputPorts)
            {
                container.AddPort(device, inputPort.Port);
            }
            foreach (var outputPort in _outputPorts)
            {
                container.AddPort(device, outputPort.Port);
            }
        }

        protected void BindPort(DeviceInputPort port, DeviceInputPortInitializer initializer)
        {
            initializer.Port = port;
            _inputPorts.Add(initializer);
        }

        protected void BindPort(DeviceOutputPort port, DeviceOutputPortInitializer initializer)
        {
            initializer.Port = port;
            _outputPorts.Add(initializer);
        }
    }
}
