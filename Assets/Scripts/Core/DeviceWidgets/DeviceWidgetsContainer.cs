using UnityEngine;

namespace Perelesoq.TestAssignment.Core.DeviceWidgets
{
    public sealed class DeviceWidgetsContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;

        public T CreateWidget<T>(T prefab)
            where T : DeviceWidgetView
        {
            var widget = Instantiate(prefab, _container);
            return widget;
        }
    }
}
