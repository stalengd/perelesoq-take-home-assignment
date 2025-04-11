using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDevice : Device
    {
        public DeviceInputPort Input { get; }
        public DeviceOutputPort Output { get; }

        public ReadOnlyReactiveProperty<bool> IsActive => _isActive;

        private readonly ReactiveProperty<bool> _isActive = new(false);

        public SwitchDevice(bool isActive)
        {
            Input = new();
            Output = new(isActive);

            _isActive.Value = isActive;

            Input.IsPowered
                .Skip(1)
                .Subscribe(OnInputPowered);
        }

        public void Switch(bool isActive)
        {
            _isActive.Value = isActive;
            Network.SetOutputActive(Output, isActive);
        }

        private void OnInputPowered(bool isPowered)
        {
            Network.SetOutputPowered(Output, isPowered);
        }
    }
}
