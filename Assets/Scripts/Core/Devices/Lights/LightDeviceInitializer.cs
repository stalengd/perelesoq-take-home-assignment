using Perelesoq.TestAssignment.Core.ControlPanel;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPort;
        [SerializeField] private LightDeviceGameView _gameView;
        [SerializeField] private LightDeviceWidgetView _widgetPrefab;
        [Space]
        [SerializeField] private float _powerUsage = 100f;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;

        public override Device Initialize()
        {
            var device = new LightDevice(_powerUsage);
            BindPort(device.Input, _inputPort);
            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new LightDevicePresenter(
                device as LightDevice,
                _gameView,
                _controlPanelPresenter.CreateWidget(_widgetPrefab));
        }
    }
}
