using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Doors
{
    public sealed class DoorDevicePresenter : DevicePresenter
    {
        private readonly DoorDevice _device;
        private readonly DoorDeviceGameView _gameView;
        private readonly DoorDeviceWidgetView _widgetView;

        public DoorDevicePresenter(
            DoorDevice device,
            DoorDeviceGameView gameView,
            DoorDeviceWidgetView widgetView)
        {
            _device = device;
            _gameView = gameView;
            _widgetView = widgetView;
        }

        public override void Start()
        {
            _widgetView.SetName(_device.Metadata?.Name);
            _widgetView.ToggleStateClicked
                .Subscribe(_ => _device.ToggleState())
                .AddTo(Disposables);
            _device.State
                .Subscribe(state =>
                {
                    switch (state)
                    {
                        case DoorState.Opened:
                            _widgetView.SetOpenedState();
                            break;
                        case DoorState.Opening:
                            _widgetView.SetOpeningState();
                            break;
                        case DoorState.Closed:
                            _widgetView.SetClosedState();
                            break;
                        case DoorState.Closing:
                            _widgetView.SetClosingState();
                            break;
                    }
                })
                .AddTo(Disposables);
        }

        public override void Update()
        {
            var target = _device.State.CurrentValue is DoorState.Opening or DoorState.Opened;
            var targetRatio = target ? 1f : 0f;
            _gameView.SetState(
                Mathf.Lerp(targetRatio, 1f - targetRatio, (float)(_device.TimeToArrive / _device.TransitionDuration)),
                target);
        }
    }
}
