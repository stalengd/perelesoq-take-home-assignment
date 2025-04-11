using Perelesoq.TestAssignment.Core.ControlPanel;
using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private TMP_Text _statusText;

        public void SetIsOn(bool isOn)
        {
            _statusText.text = isOn ? "on" : "off";
        }
    }
}
