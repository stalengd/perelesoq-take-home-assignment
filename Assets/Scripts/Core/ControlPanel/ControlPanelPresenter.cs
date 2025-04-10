using System;
using Perelesoq.TestAssignment.Core.Devices;
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
                _view.SetPowerLimit(powerSource.MaxPower);
                powerSource.PowerUsage
                    .Subscribe(power => _view.SetCurrentPower(power))
                    .AddTo(ref _disposables);
                Observable.Interval(TimeSpan.FromSeconds(1f))
                    .Subscribe(x => _view.SetTime(powerSource.Uptime))
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
