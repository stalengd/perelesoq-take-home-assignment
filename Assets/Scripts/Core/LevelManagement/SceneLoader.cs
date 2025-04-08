using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace Perelesoq.TestAssignment.Core.LevelManagement
{
    public sealed class SceneLoader
    {
        private readonly ProjectScenes _projectScenes;

        private GameLevel _loadedLevel;

        public SceneLoader(ProjectScenes projectScenes)
        {
            _projectScenes = projectScenes;
        }

        public async UniTask LoadLevel(GameLevel level)
        {
            await UnloadLevel();

            if (level == null)
            {
                return;
            }

            _loadedLevel = level;

            await UniTask.WhenAll(
                SceneManager.LoadSceneAsync(_loadedLevel.MainScene, LoadSceneMode.Additive).ToUniTask(),
                SceneManager.LoadSceneAsync(_loadedLevel.EnvironmentScene, LoadSceneMode.Additive).ToUniTask(),
                SceneManager.LoadSceneAsync(_loadedLevel.LightsScene, LoadSceneMode.Additive).ToUniTask(),
                SceneManager.LoadSceneAsync(_loadedLevel.NavigationScene, LoadSceneMode.Additive).ToUniTask(),
                SceneManager.LoadSceneAsync(_projectScenes.LevelUserInterfaceScene, LoadSceneMode.Additive).ToUniTask()
                );

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(_loadedLevel.MainScene));
        }

        public async UniTask UnloadLevel()
        {
            if (_loadedLevel == null)
            {
                return;
            }

            await UniTask.WhenAll(
                SceneManager.UnloadSceneAsync(_loadedLevel.MainScene).ToUniTask(),
                SceneManager.UnloadSceneAsync(_loadedLevel.EnvironmentScene).ToUniTask(),
                SceneManager.UnloadSceneAsync(_loadedLevel.LightsScene).ToUniTask(),
                SceneManager.UnloadSceneAsync(_loadedLevel.NavigationScene).ToUniTask(),
                SceneManager.UnloadSceneAsync(_projectScenes.LevelUserInterfaceScene).ToUniTask()
                );

            _loadedLevel = null;
        }
    }
}
