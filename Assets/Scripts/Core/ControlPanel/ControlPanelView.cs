using UnityEngine;

namespace Perelesoq.TestAssignment.Core.ControlPanel
{
    public sealed class ControlPanelView : MonoBehaviour
    {
        [SerializeField] private Transform _widgetsContainer;

        public T CreateWidget<T>(T prefab)
            where T : DeviceWidgetView
        {
            var widget = Instantiate(prefab, _widgetsContainer);
            return widget;
        }
    }
}
