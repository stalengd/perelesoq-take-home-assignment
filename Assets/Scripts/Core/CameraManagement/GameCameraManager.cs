using Perelesoq.TestAssignment.Core.Devices.Cameras;
using R3;

namespace Perelesoq.TestAssignment.Core.CameraManagement
{
    public sealed class GameCameraManager
    {
        public ReactiveProperty<CameraDevice> ActiveCamera { get; } = new();
    }
}
