using System;
using Perelesoq.TestAssignment.Core.ControlPanel;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Devices.Doors
{
    public sealed class DoorDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [SerializeField] private DoorDeviceGameView _gameView;
        [SerializeField] private DoorDeviceWidgetView _widgetPrefab;
        [Space]
        [SerializeField] private float _transitionDurationSeconds = 5f;
        [SerializeField] private float _activeRequiredPower = 100;
        [SerializeField] private bool _isOpened;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;

        public override Device Initialize()
        {
            var device = new DoorDevice(
                TimeSpan.FromSeconds(_transitionDurationSeconds), _activeRequiredPower, _isOpened);
            BindPort(device.Input, _inputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new DoorDevicePresenter(
                device as DoorDevice,
                _gameView,
                _controlPanelPresenter.CreateWidget(_widgetPrefab));
        }
    }
}
