using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDevicePresenter : DevicePresenter
    {
        private readonly SwitchDevice _device;
        private readonly SwitchDeviceWidgetView _widget;

        public SwitchDevicePresenter(SwitchDevice device, SwitchDeviceWidgetView widget)
        {
            _device = device;
            _widget = widget;
        }

        public override void Start()
        {
            _widget.Toggled
                .Subscribe(v => _device.Switch(v))
                .AddTo(Disposables);
        }
    }
}
