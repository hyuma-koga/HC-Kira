using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[]     stagePrefabs;
    [SerializeField] private GameOverManager  gameOverManager;
    [SerializeField] private GameClearManager gameClearManager;
    [SerializeField] private GameUI           gameUI;
    [SerializeField] private GameObject       stageSelectUI;
    [SerializeField] private Transform        stageParent;
    [SerializeField] private int              currentStageIndex = 0;

    public static StageManager                Instance { get; private set; }
    private GameObject                        currentStageInstance;
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SpawnStage(int index)
    {
        if (index < 0 || index >= stagePrefabs.Length)
        {
            return;
        }

        currentStageInstance = Instantiate(stagePrefabs[index], stageParent);

        RegisterBallForUI(currentStageInstance);
        RegisterBalloonsInStage(currentStageInstance);
    }

    public void RestartStage()
    {
        if (currentStageInstance != null)
        {
            Destroy(currentStageInstance);
        }

        if (BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.ResetCounter();
        }

        if (gameUI != null)
        {
            gameUI.gameObject.SetActive(true);
        }

        SpawnStage(currentStageIndex);

        if (gameOverManager != null)
        {
            gameOverManager.ResetGameOver();
        }
    }

    private void RegisterBallForUI(GameObject stageInstance)
    {
        var ballObj = stageInstance.transform.Find("Ball");

        if (ballObj != null && gameUI != null)
        {
            var rb = ballObj.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                gameUI.SetBall(rb);
            }
        }
    }

    private void RegisterBalloonsInStage(GameObject stageInstance)
    {
        Transform balloonRoot = stageInstance.transform.Find("Balloon");

        if (balloonRoot != null && BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.RegisterBalloon(balloonRoot);
        }
    }

    public void LoadStage(int index)
    {
        currentStageIndex = index;

        if (currentStageInstance != null)
        {
            Destroy(currentStageInstance);
        }

        if (BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.ResetCounter();
        }


        if (gameUI != null)
        {
            gameUI.gameObject.SetActive(true);
        }

        gameOverManager?.ResetGameOver();
        gameClearManager?.ResetGameClear();
        currentStageInstance = Instantiate(stagePrefabs[index], stageParent);
        RegisterBalloonsInStage(currentStageInstance);
        RegisterBallForUI(currentStageInstance);
        gameUI?.UpdateStageNumber(index);
    }

    public void LoadNextStage()
    {
        currentStageIndex++;

        if (currentStageIndex >= stagePrefabs.Length)
        {
            return;
        }

        if (gameClearManager != null)
        {
            gameClearManager.ResetGameClear();
        }

        if (BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.ResetCounter();
        }

        gameUI?.UpdateStageNumber(currentStageIndex);
        RestartStage();
    }

    public void ReturnToStageSelect()
    {
        if (currentStageInstance != null)
        {
            Destroy(currentStageInstance);
        }

        if (gameOverManager != null)
        {
            gameOverManager.ResetGameOver();
        }

        if (gameUI != null)
        {
            gameUI.gameObject.SetActive(false);
        }

        stageSelectUI.SetActive(true);
    }
}