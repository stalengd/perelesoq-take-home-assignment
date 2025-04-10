using Perelesoq.TestAssignment.Core.CameraManagement;
using Perelesoq.TestAssignment.Core.ControlPanel;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Devices.Cameras
{
    public sealed class CameraDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private CameraDeviceGameView _gameView;
        [SerializeField] private CameraDeviceWidgetView _widgetPrefab;
        [Space]
        [SerializeField] private bool _isActiveAtStart = false;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;
        [Inject] private readonly GameCameraManager _gameCameraManager;
        [Inject] private readonly GameCameraPresenter _gameCameraPresenter;

        public override Device Initialize()
        {
            var device = new CameraDevice();
            if (_isActiveAtStart)
            {
                _gameCameraManager.ActiveCamera.Value = device;
            }
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            var cameraDevice = device as CameraDevice;
            return new CameraDevicePresenter(
                cameraDevice,
                _gameView,
                _controlPanelPresenter.CreateWidget(_widgetPrefab),
                _gameCameraManager,
                _gameCameraPresenter);
        }
    }
}
