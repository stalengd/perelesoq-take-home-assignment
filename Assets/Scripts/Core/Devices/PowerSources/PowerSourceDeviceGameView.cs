using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.PowerSources
{
    public sealed class PowerSourceDeviceGameView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statusText;

        private readonly StringBuilder _buffer = new();

        public void SetStatus(TimeSpan time, float currentPower, float totalPower, float consumedEnergyKilowattHours)
        {
            _buffer.Clear();
            _buffer.AppendLine($"TIME: {time:d'd 'h'h 'm'm 's's'}");
            _buffer.AppendLine($"TOTAL: {consumedEnergyKilowattHours:F2}kWh");
            _buffer.AppendLine($"CURRENT: {currentPower:F0}W/{totalPower:F0}W");
            _statusText.SetText(_buffer);
        }
    }
}
