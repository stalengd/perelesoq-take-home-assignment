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
        [SerializeField] private SwitchDeviceWidgetView _widgetPrefab;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;

        public override Device Initialize()
        {
            var device = new SwitchDevice();
            BindPort(device.Input, _inputPort);
            BindPort(device.Output, _outputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new SwitchDevicePresenter(device as SwitchDevice,
                _controlPanelPresenter.CreateWidget(_widgetPrefab));
        }
    }
}
