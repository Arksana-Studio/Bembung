using UnityEditor;
using UnityEngine;
using Utilities.SavingSystem;

namespace StageLevel
{
    public class LevelListUIMenu : MonoBehaviour
    {
        public SceneAsset[] sceneList;
        private SaveManager _saveManager;

        private void Start()
        {
            var loadLevelManager = LoadLevelManager.Instance;
            _saveManager = SaveManager.Instance;

            for (int i = 0; i < sceneList.Length; i++)
            {
                var currentIndex = i;
                var sceneBtnGameObject = Instantiate(GamePrefabs.Instance.levelUIBtn, transform.GetChild(0));
                sceneBtnGameObject.TryGetComponent(out LevelSelectButtonUI levelSelectButtonUI);
                levelSelectButtonUI.level = i + 1;
                levelSelectButtonUI.onClick.AddListener(() =>
                    loadLevelManager.LoadLevel(sceneList[currentIndex].name));
                if (levelSelectButtonUI.level <= _saveManager.saveData.levelUnlockedStandard)
                {
                    levelSelectButtonUI.UnlockLevel();
                }
            }
        }
    }
}