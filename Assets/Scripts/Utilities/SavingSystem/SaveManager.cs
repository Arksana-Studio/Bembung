using Base;
using UnityEditor;
using UnityEngine;

namespace Utilities.SavingSystem
{
    public class SaveManager : SingletonMonoBehaviour<SaveManager>
    {
        public SaveData saveData;

        private void SavePlayerData()
        {
            var mainData = JsonUtility.ToJson(saveData);
            var standardData = JsonHelper.ToJson(saveData.scoreListStandard);
            PlayerPrefs.SetString(SaveDataConst.PlayerSaveDataKey, mainData);
            PlayerPrefs.SetString(SaveDataConst.StandardKey, standardData);
            PlayerPrefs.Save();
            print("Save Data!");
        }

        private void LoadPlayerData()
        {
            var playerData = PlayerPrefs.GetString(SaveDataConst.PlayerSaveDataKey);
            var standardData = PlayerPrefs.GetString(SaveDataConst.StandardKey);
            saveData = JsonUtility.FromJson<SaveData>(playerData);
            saveData.scoreListStandard = JsonHelper.FromJson<int>(standardData);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(SaveManager))]
        class SaveManagerEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                var saveManager = (SaveManager)target;

                if (GUILayout.Button("Save Data"))
                    saveManager.SavePlayerData();
                if (GUILayout.Button("Load Data"))
                    saveManager.LoadPlayerData();
            }
        }
#endif
    }
}