using UnityEditor;
using UnityEngine;

namespace StageLevel
{
    public class LevelListUIMenu : MonoBehaviour
    {
        public SceneAsset[] sceneList;

        private void Start()
        {
            var loadLevelManager = LoadLevelManager.Instance;

            for (int i = 0; i < sceneList.Length; i++)
            {
                var sceneBtnGameObject = Instantiate(GamePrefabs.Instance.levelUIBtn, transform.GetChild(0));
                sceneBtnGameObject.TryGetComponent(out LevelSelectButtonUI levelSelectButtonUI);
                levelSelectButtonUI.level = i + 1;
                var currentIndex = i;
                levelSelectButtonUI.onClick.AddListener(() =>
                {
                    loadLevelManager.LoadLevel(sceneList[currentIndex].name);
                });
            }
        }

        void UnlockLevel(int level)
        {
        }
    }
}