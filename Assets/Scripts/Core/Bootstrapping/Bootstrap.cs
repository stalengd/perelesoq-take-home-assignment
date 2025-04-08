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

        private async void Start()
        {
            _levels = new GameLevelsConfig();
            _sceneLoader = new SceneLoader(_levels.ProjectScenes);
            await _sceneLoader.LoadLevel(_levels.TestLevel);

            _loadingScreen.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload().Forget();
            }
        }

        private async UniTask Reload()
        {
            _loadingScreen.SetActive(true);
            await _sceneLoader.LoadLevel(_levels.TestLevel);
            _loadingScreen.SetActive(false);
        }
    }
}
