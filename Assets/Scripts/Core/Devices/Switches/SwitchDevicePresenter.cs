using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDevicePresenter : DevicePresenter
    {
        private readonly SwitchDevice _device;
        private readonly SwitchDeviceGameView _gameView;
        private readonly SwitchDeviceWidgetView _widget;

        public SwitchDevicePresenter(
            SwitchDevice device,
            SwitchDeviceGameView gameView,
            SwitchDeviceWidgetView widget)
        {
            _device = device;
            _gameView = gameView;
            _widget = widget;
        }

        public override void Start()
        {
            _widget.SetName(_device.Metadata?.Name);
            _widget.Toggled
                .Skip(1)
                .Subscribe(v => _device.Switch(v))
                .AddTo(Disposables);
            _device.IsActive
                .Subscribe(isActive =>
                {
                    _gameView.SetIsOn(isActive);
                    _widget.SetIsOn(isActive);
                })
                .AddTo(Disposables);
        }
    }
}
