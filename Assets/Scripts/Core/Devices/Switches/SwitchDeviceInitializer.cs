using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using Perelesoq.TestAssignment.Core.DeviceWidgets;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [SerializeField] private DeviceOutputPortInitializer _outputPort;
        [SerializeField] private SwitchDeviceWidgetView _widgetPrefab;

        public override Device Initialize(DeviceNetwork network)
        {
            var device = new SwitchDevice();
            network.AddDevice(device);
            BindPort(device.Input, _inputPort);
            BindPort(device.Output, _outputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device, DeviceWidgetsContainer widgetsContainer)
        {
            return new SwitchDevicePresenter(device as SwitchDevice, widgetsContainer.CreateWidget(_widgetPrefab));
        }
    }
}
