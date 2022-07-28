using System.Collections.Generic;
using Base;
using TMPro;
using UnityEngine;

public class GamePrefabs : SingletonMonoBehaviour<GamePrefabs>
{
    [Header("Gameplay")] public GameObject ringPrefab;
    public GameObject ringsParent;
    [HideInInspector] public List<Rigidbody> ringRigidbodyList;
    public List<GameObject> ringSpawnPositionList;

    [Header("UI")] public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text countDownText;
    public GameObject gameOverUI;
    public GameObject gameplayUI;
    public TMP_Text gameOverTimeText;
    public TMP_Text gameOverScoreText;

    [Header("Level UI")] public GameObject levelUIBtn;
}