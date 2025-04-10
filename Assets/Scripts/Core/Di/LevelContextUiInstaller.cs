using Perelesoq.TestAssignment.Core.ControlPanel;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Di
{
    public sealed class LevelContextUiInstaller : LevelContextInstaller
    {
        [SerializeField] private ControlPanelView _controlPanelView;

        public override void InstallBindings()
        {
            Container.BindInstance(_controlPanelView);
        }
    }
}
