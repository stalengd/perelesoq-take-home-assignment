using Cysharp.Threading.Tasks;
using Perelesoq.TestAssignment.Core.LevelManagement;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Bootstrapping
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;

        private GameLevelsConfig _levels;
        private SceneLoader _sceneLoader;
        private bool _isLoading = false;

        private async void Start()
        {
            _levels = new GameLevelsConfig();
            _sceneLoader = new SceneLoader(_levels.ProjectScenes);
            await Handle(_sceneLoader.LoadLevel(_levels.TestLevel));
        }

        private void Update()
        {
            if (_isLoading)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload().Forget();
            }
        }

        private async UniTask Reload()
        {
            await Handle(_sceneLoader.LoadLevel(_levels.TestLevel));
        }

        private async UniTask Handle(UniTask task)
        {
            _isLoading = true;
            _loadingScreen.SetActive(_isLoading);

            await task;

            _isLoading = false;
            _loadingScreen.SetActive(_isLoading);
        }
    }
}
