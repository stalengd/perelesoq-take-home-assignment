using Perelesoq.TestAssignment.Core.CameraManagement;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Di
{
    public sealed class LevelModelInstaller : Installer<LevelModelInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameCameraManager>()
                .AsSingle();
        }
    }
}
