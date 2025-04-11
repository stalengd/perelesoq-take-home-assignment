using System;
using Perelesoq.TestAssignment.Core.Devices;
using Perelesoq.TestAssignment.Core.Util;
using R3;
using Zenject;

namespace Perelesoq.TestAssignment.Core.ControlPanel
{
    public sealed class ControlPanelPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly ControlPanelView _view;
        [Inject] private readonly DeviceNetwork _deviceNetwork;

        private DisposableBag _disposables;

        public void Initialize()
        {
            if (_deviceNetwork.PowerSource is { } powerSource)
            {
                powerSource.PowerUsage
                    .Subscribe(power => _view.SetPower(power, powerSource.MaxPower))
                    .AddTo(ref _disposables);
                Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1f))
                    .Subscribe(_ =>
                    {
                        _view.SetTime(powerSource.Uptime);
                        _view.SetConsumedEnergy(
                            PowerMath.WattHourToKilowattHour(
                            PowerMath.WattSecondToWattHour(powerSource.EnergyConsumed)));
                    })
                    .AddTo(ref _disposables);
            }
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public T CreateWidget<T>(T prefab)
            where T : DeviceWidgetView
        {
            return _view.CreateWidget(prefab);
        }
    }
}
