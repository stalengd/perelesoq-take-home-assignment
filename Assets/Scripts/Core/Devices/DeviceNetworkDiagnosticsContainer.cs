using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices
{
    public sealed class DeviceNetworkDiagnosticsContainer
    {
        private readonly DeviceNetwork _deviceNetwork;
        private readonly Dictionary<Device, (List<DeviceInputPort> inputs, List<DeviceOutputPort> outputs)> _devicePorts = new();
        private readonly Dictionary<DeviceInputPort, int> _inputIds = new();
        private readonly Dictionary<DeviceOutputPort, int> _outputIds = new();
        private int _nextId = 0;

        public DeviceNetworkDiagnosticsContainer(DeviceNetwork deviceNetwork)
        {
            _deviceNetwork = deviceNetwork;
        }

        public void AddPort(Device device, DeviceInputPort port)
        {
            if (!_devicePorts.TryGetValue(device, out var ports))
            {
                ports = (new(), new());
                _devicePorts[device] = ports;
            }
            ports.inputs.Add(port);
            _inputIds[port] = _nextId++;
        }

        public void AddPort(Device device, DeviceOutputPort port)
        {
            if (!_devicePorts.TryGetValue(device, out var ports))
            {
                ports = (new(), new());
                _devicePorts[device] = ports;
            }
            ports.outputs.Add(port);
            _outputIds[port] = _nextId++;
        }

        public void LogDevicesTable()
        {
            var devices = _deviceNetwork.Devices.ToList();

            var stringBuilder = new StringBuilder();
            for (var i = 0; i < devices.Count; i++)
            {
                var device = devices[i];
                stringBuilder.Append(device.GetType().Name);
                stringBuilder.Append(' ');
                stringBuilder.Append("\t");
                foreach (var input in _devicePorts[device].inputs)
                {
                    var index = _inputIds[input];
                    var outIndex = input.Connection.Value != null
                        ? _outputIds[input.Connection.Value]
                        : -1;
                    stringBuilder.Append($"IN({index})=OUT({outIndex}) P={input.IsPowered.Value} \t| ");
                }
                foreach (var output in _devicePorts[device].outputs)
                {
                    var index = _outputIds[output];
                    stringBuilder.Append($"OUT({index}) A={output.IsActive.Value} P={output.IsPowered.Value} \t| ");
                }
                stringBuilder.AppendLine();
            }

            Debug.Log(stringBuilder.ToString());
        }
    }
}
