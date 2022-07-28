using Base;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace StageLevel
{
    public class LevelSelectButtonUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelUIText;
        [SerializeField] private Image bg;
        [SerializeField] private Image frontBg;
        [SerializeField] private GameMode gameMode = GameMode.Standard;
        public int level;
        [SerializeField] public UnityEvent onClick;

        public bool isLocked = true;
        [SerializeField] private Button button;
        [SerializeField] private AudioSource audioSource;

        public void UnlockLevel()
        {
            // PlayUnlockAnimation();
            UnlockingLevelUI();
        }

        private void UnlockingLevelUI()
        {
            isLocked = false;
            levelUIText.text = $"{level}";
            levelUIText.fontSize = 24f;
            frontBg.enabled = false;
            button.interactable = true;
            button.enabled = true;
            button.interactable = true;
            button.onClick.AddListener(onClick.Invoke);
            
        }

        private void PlayUnlockAnimation()
        {
            audioSource.Play();
        }

        [CustomEditor(typeof(LevelSelectButtonUI))]
        class LevelSelectButtonUIEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();
                var levelSelectButtonUI = (LevelSelectButtonUI)target;

                if (GUILayout.Button("Unlock Level"))
                    levelSelectButtonUI.UnlockLevel();
            }
        }
    }
}