using Perelesoq.TestAssignment.Core.CameraManagement;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Cameras
{
    public sealed class CameraDevicePresenter : DevicePresenter
    {
        private readonly CameraDevice _device;
        private readonly CameraDeviceGameView _gameView;
        private readonly CameraDeviceWidgetView _widgetView;
        private readonly GameCameraManager _gameCameraManager;
        private readonly GameCameraPresenter _gameCameraPresenter;

        public CameraDevicePresenter(
            CameraDevice device,
            CameraDeviceGameView gameView,
            CameraDeviceWidgetView widgetView,
            GameCameraManager gameCameraManager,
            GameCameraPresenter gameCameraPresenter)
        {
            _device = device;
            _gameView = gameView;
            _widgetView = widgetView;
            _gameCameraManager = gameCameraManager;
            _gameCameraPresenter = gameCameraPresenter;
        }

        public override void Start()
        {
            _gameCameraPresenter.RegisterCameraView(_device, _gameView);
            _widgetView.SelectClicked
                .Subscribe(_ =>
                {
                    _gameCameraManager.ActiveCamera.Value = _device;
                })
                .AddTo(Disposables);
        }
    }
}
