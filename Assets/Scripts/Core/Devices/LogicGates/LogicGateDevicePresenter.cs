using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.LogicGates
{
    public sealed class LogicGateDevicePresenter : DevicePresenter
    {
        private readonly LogicGateDevice _device;
        private readonly LogicGateDeviceGameView _gameView;
        private readonly LogicGateDeviceWidgetView _widgetView;

        public LogicGateDevicePresenter(
            LogicGateDevice device,
            LogicGateDeviceGameView gameView,
            LogicGateDeviceWidgetView widgetView)
        {
            _device = device;
            _gameView = gameView;
            _widgetView = widgetView;
        }

        public override void Start()
        {
            _widgetView.SetName(_device.Metadata?.Name);
            _device.InputA.IsPowered
                .Subscribe(v =>
                {
                    _gameView.SetInputAPowered(v);
                })
                .AddTo(Disposables);
            _device.InputB.IsPowered
                .Subscribe(v =>
                {
                    _gameView.SetInputBPowered(v);
                })
                .AddTo(Disposables);
            _device.Output.IsPowered
                .Subscribe(v =>
                {
                    _gameView.SetOutputPowered(v);
                    _widgetView.SetIsOpen(v);
                })
                .AddTo(Disposables);
        }
    }
}
