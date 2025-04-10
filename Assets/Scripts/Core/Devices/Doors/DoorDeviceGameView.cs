using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Doors
{
    public sealed class DoorDeviceGameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _stateText;
        [SerializeField] private Transform _doorShaft;
        [SerializeField] private Vector3 _openedRotation;
        [SerializeField] private Vector3 _closedRotation;

        public void SetState(float openedRatio, bool targetState)
        {
            _doorShaft.localRotation = Quaternion.Slerp(
                Quaternion.Euler(_closedRotation),
                Quaternion.Euler(_openedRotation),
                openedRatio);

            if (targetState)
            {
                if (Mathf.Approximately(openedRatio, 1f))
                {
                    _stateText.text = "opened";
                }
                else
                {
                    _stateText.text = "opening";
                }
            }
            else
            {
                if (Mathf.Approximately(openedRatio, 0f))
                {
                    _stateText.text = "closed";
                }
                else
                {
                    _stateText.text = "closing";
                }
            }
        }
    }
}
