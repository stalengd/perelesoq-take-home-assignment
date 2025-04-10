using Perelesoq.TestAssignment.Core.ControlPanel;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Perelesoq.TestAssignment.Core.Devices.Cameras
{
    public sealed class CameraDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private Button _button;

        public Observable<Unit> SelectClicked => _button.OnClickAsObservable();
    }
}
