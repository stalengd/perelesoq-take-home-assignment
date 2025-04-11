using Cysharp.Threading.Tasks;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDevicePresenter : DevicePresenter
    {
        private readonly LightDevice _device;
        private readonly LightDeviceGameView _gameView;
        private readonly LightDeviceWidgetView _widgetView;

        public LightDevicePresenter(
            LightDevice device,
            LightDeviceGameView gameView,
            LightDeviceWidgetView widgetView)
        {
            _device = device;
            _gameView = gameView;
            _widgetView = widgetView;
        }

        public override void Start()
        {
            _widgetView.SetName(_device.Metadata?.Name);
            _device.Input.IsPowered
                .Subscribe(isPowered =>
                {
                    _gameView.SetEmittingLight(isPowered);
                    _widgetView.SetIsOn(isPowered);
                })
                .AddTo(Disposables);
        }
    }
}
