using Perelesoq.TestAssignment.Core.ControlPanel;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [SerializeField] private DeviceOutputPortInitializer _outputPort;
        [SerializeField] private SwitchDeviceGameView _gameView;
        [SerializeField] private SwitchDeviceWidgetView _widgetPrefab;
        [Space]
        [SerializeField] private bool _isActive = true;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;

        public override Device Initialize()
        {
            var device = new SwitchDevice(_isActive);
            BindPort(device.Input, _inputPort);
            BindPort(device.Output, _outputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new SwitchDevicePresenter(
                device as SwitchDevice,
                _gameView,
                _controlPanelPresenter.CreateWidget(_widgetPrefab));
        }
    }
}
