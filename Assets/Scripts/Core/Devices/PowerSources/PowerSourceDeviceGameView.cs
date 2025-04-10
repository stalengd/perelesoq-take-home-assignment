using System;
using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDeviceGameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statusText;

        public void SetStatus(TimeSpan time, float currentPower, float totalPower)
        {
            _statusText.text = $"TIME: {time:d'd 'h'h 'm'm 's's'}\nTOTAL: {totalPower:F0}W\nCURRENT: {currentPower:F0}W";
        }
    }
}
