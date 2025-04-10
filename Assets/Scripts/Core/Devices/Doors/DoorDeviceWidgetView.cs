using Perelesoq.TestAssignment.Core.ControlPanel;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Perelesoq.TestAssignment.Core.Devices.Doors
{
    public sealed class DoorDeviceWidgetView : DeviceWidgetView
    {
        [SerializeField] private Button _toggleStateButton;
        [SerializeField] private TMP_Text _toggleStateButtonLabel;
        [SerializeField] private TMP_Text _stateText;

        public Observable<Unit> ToggleStateClicked => _toggleStateButton.OnClickAsObservable();

        public void SetOpenedState()
        {
            _stateText.text = "opened";
            _toggleStateButtonLabel.text = "CLOSE";
        }

        public void SetOpeningState()
        {
            _stateText.text = "opening";
            _toggleStateButtonLabel.text = "CLOSE";
        }

        public void SetClosedState()
        {
            _stateText.text = "closed";
            _toggleStateButtonLabel.text = "OPEN";
        }

        public void SetClosingState()
        {
            _stateText.text = "closing";
            _toggleStateButtonLabel.text = "OPEN";
        }
    }
}
