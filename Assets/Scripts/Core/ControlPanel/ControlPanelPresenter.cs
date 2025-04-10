using Zenject;

namespace Perelesoq.TestAssignment.Core.ControlPanel
{
    public sealed class ControlPanelPresenter
    {
        [Inject] private readonly ControlPanelView _view;

        public T CreateWidget<T>(T prefab)
            where T : DeviceWidgetView
        {
            return _view.CreateWidget(prefab);
        }
    }
}
