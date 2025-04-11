using System;
using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.ControlPanel
{
    public sealed class ControlPanelView : MonoBehaviour
    {
        [SerializeField] private Transform _widgetsContainer;
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private TMP_Text _currentPowerText;
        [SerializeField] private TMP_Text _consumedEnergyText;

        public T CreateWidget<T>(T prefab)
            where T : DeviceWidgetView
        {
            var widget = Instantiate(prefab, _widgetsContainer);
            return widget;
        }

        public void SetTime(TimeSpan time)
        {
            _timeText.text = time.ToString(@"d'd 'h'h 'm'm 's's'");
        }

        public void SetPower(float power, float powerLimit)
        {
            _currentPowerText.text = $"{power}W/{powerLimit}W";
        }

        public void SetConsumedEnergy(float energyKilowattHours)
        {
            _consumedEnergyText.text = $"{energyKilowattHours:F2}kWh";
        }
    }
}
