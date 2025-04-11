using Perelesoq.TestAssignment.Core.ControlPanel;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private TMP_Text _statusText;

        public Observable<bool> Toggled => _toggle.OnValueChangedAsObservable();

        public void SetIsOn(bool isOn)
        {
            _statusText.text = isOn ? "on" : "off";
            _toggle.SetIsOnWithoutNotify(isOn);
        }
    }
}
