using System;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDevicePresenter : DevicePresenter
    {
        private readonly PowerSourceDevice _device;
        private readonly PowerSourceDeviceGameView _gameView;

        public PowerSourceDevicePresenter(PowerSourceDevice device, PowerSourceDeviceGameView gameView)
        {
            _device = device;
            _gameView = gameView;
        }

        public override void Start()
        {
            Observable.Interval(TimeSpan.FromSeconds(1f))
                .Subscribe(x => _gameView.SetStatus(
                    _device.Uptime,
                    _device.PowerUsage.CurrentValue,
                    _device.MaxPower))
                .AddTo(Disposables);
        }
    }
}
