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
        [SerializeField] private TMP_Text _powerLimitText;

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

        public void SetCurrentPower(float power)
        {
            _currentPowerText.text = $"{power}W";
        }

        public void SetPowerLimit(float power)
        {
            _powerLimitText.text = $"{power}W";
        }
    }
}
