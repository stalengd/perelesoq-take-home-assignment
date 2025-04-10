using Perelesoq.TestAssignment.Core.ControlPanel;
using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.LogicGates
{
    public sealed class LogicGateDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private TMP_Text _stateText;

        public void SetIsOpen(bool isOpen)
        {
            // This should be localized in real-life scenario, you know.
            _stateText.text = isOpen ? "opened" : "closed";
        }
    }
}
