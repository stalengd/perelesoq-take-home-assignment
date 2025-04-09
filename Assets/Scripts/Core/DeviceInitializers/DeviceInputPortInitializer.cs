using Perelesoq.TestAssignment.Core.Devices;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.DeviceInitializers
{
    public sealed class DeviceInputPortInitializer : MonoBehaviour
    {
        [SerializeField] private DeviceOutputPortInitializer _connectedTo;

        public DeviceInputPort Port { get; set; }
        public DeviceOutputPortInitializer ConnectedTo => _connectedTo;
    }
}
