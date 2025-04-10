using Perelesoq.TestAssignment.Core.ControlPanel;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Devices.LogicGates
{
    public sealed class LogicGateDeviceInitializer : DeviceInitializer
    {
        [SerializeField] private DeviceInputPortInitializer _inputPortA;
        [SerializeField] private DeviceInputPortInitializer _inputPortB;
        [SerializeField] private DeviceOutputPortInitializer _outputPort;
        [SerializeField] private LogicGateDeviceGameView _gameView;
        [SerializeField] private LogicGateDeviceWidgetView _widgetPrefab;
        [Space]
        [SerializeField] private LogicOperation _operation;

        [Inject] private readonly ControlPanelPresenter _controlPanelPresenter;

        public override Device Initialize()
        {
            var device = new LogicGateDevice(_operation);

            BindPort(device.InputA, _inputPortA);
            BindPort(device.InputB, _inputPortB);
            BindPort(device.Output, _outputPort);

            return device;
        }

        public override DevicePresenter InitializePresenter(Device device)
        {
            return new LogicGateDevicePresenter(
                device as LogicGateDevice,
                _gameView,
                _controlPanelPresenter.CreateWidget(_widgetPrefab));
        }
    }
}
