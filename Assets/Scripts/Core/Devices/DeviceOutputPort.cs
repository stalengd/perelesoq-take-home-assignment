using ObservableCollections;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices
{
    public sealed class DeviceOutputPort
    {
        public ObservableHashSet<DeviceInputPort> Connections { get; } = new();
        public ReactiveProperty<bool> IsActive { get; } = new(true);
        public ReactiveProperty<bool> IsPowered { get; } = new(false);
    }
}
