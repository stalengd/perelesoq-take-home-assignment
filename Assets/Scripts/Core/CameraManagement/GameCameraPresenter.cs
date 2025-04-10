using System;
using System.Collections.Generic;
using Perelesoq.TestAssignment.Core.Devices.Cameras;
using R3;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.CameraManagement
{
    public sealed class GameCameraPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly GameCameraManager _gameCameraManager;
        [Inject] private readonly GameCameraView _view;

        private readonly Dictionary<CameraDevice, CameraDeviceGameView> _registeredCameras = new();
        private DisposableBag _disposables;

        public void Initialize()
        {
            _gameCameraManager.ActiveCamera
                .Subscribe(x => AlignWithCameraDevice(x))
                .AddTo(ref _disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        public void RegisterCameraView(CameraDevice camera, CameraDeviceGameView cameraView)
        {
            _registeredCameras[camera] = cameraView;
            if (_gameCameraManager.ActiveCamera.Value == null)
            {
                _gameCameraManager.ActiveCamera.Value = camera;
            }
            else if (_gameCameraManager.ActiveCamera.Value == camera)
            {
                AlignWithCameraDevice(camera);
            }
        }

        private void AlignWithCameraDevice(CameraDevice cameraDevice)
        {
            if (!_registeredCameras.TryGetValue(cameraDevice, out var cameraView))
            {
                return;
            }
            _view.AlignViewWith(cameraView.CameraPoint);
        }
    }
}
