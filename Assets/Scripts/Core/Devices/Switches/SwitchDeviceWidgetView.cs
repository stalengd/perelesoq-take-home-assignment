using Perelesoq.TestAssignment.Core.DeviceWidgets;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private Toggle _toggle;

        public Observable<bool> Toggled => _toggle.OnValueChangedAsObservable();
    }
}
