using Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageLevel
{
    public class LoadLevelManager : SingletonMonoBehaviour<LoadLevelManager>
    {
        public AsyncOperation LoadLevel(string sceneName)
        {
            return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        }
    }
}