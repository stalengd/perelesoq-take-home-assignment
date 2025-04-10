using Perelesoq.TestAssignment.Core.CameraManagement;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Di
{
    public sealed class LevelContextMainInstaller : LevelContextInstaller
    {
        [SerializeField] private GameCameraView _gameCameraView;

        public override void InstallBindings()
        {
            Container.BindInstance(_gameCameraView);
        }
    }
}
