using UnityEngine.SceneManagement;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.SceneStuff
{
    public interface ISceneService
    {
        void GoToScene(string sceneType, LoadSceneMode mode = LoadSceneMode.Single);
    }

    public class SceneService : ISceneService
    {
        public void GoToScene(string sceneType, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneType, mode);
        }
    }
}