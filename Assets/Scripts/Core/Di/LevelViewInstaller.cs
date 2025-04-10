using Perelesoq.TestAssignment.Core.CameraManagement;
using Perelesoq.TestAssignment.Core.ControlPanel;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Di
{
    public sealed class LevelViewInstaller : Installer<LevelViewInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ControlPanelPresenter>()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<GameCameraPresenter>()
                .AsSingle();
        }
    }
}
