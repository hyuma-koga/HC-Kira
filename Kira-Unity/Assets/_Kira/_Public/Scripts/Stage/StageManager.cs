using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private GameObject[]     stagePrefabs;
    [SerializeField] private GameOverManager  gameOverManager;
    [SerializeField] private GameClearManager gameClearManager;
    [SerializeField] private Transform        stageParent;
    [SerializeField] private int              currentStageIndex = 0;

    private GameObject currentStageInstance;

    private void Start()
    {
        SpawnStage(currentStageIndex);
    }

    public void RestartStage()
    {
        if (currentStageInstance != null)
        {
            Destroy(currentStageInstance);
        }

        if (BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.ResetCounter(); // ←追加
        }

        SpawnStage(currentStageIndex);

        if (gameOverManager != null)
        {
            gameOverManager.ResetGameOver();
        }
    }

    private void SpawnStage(int index)
    {
        if (index < 0 || index >= stagePrefabs.Length)
        {
            return;
        }

        currentStageInstance = Instantiate(stagePrefabs[index], stageParent);

        RegisterBalloonsInStage(currentStageInstance);
    }

    private void RegisterBalloonsInStage(GameObject stageInstance)
    {
        Transform balloonRoot = stageInstance.transform.Find("Balloon");

        if (balloonRoot != null && BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.RegisterBalloon(balloonRoot);
        }
        else
        {
            Debug.LogWarning("Balloonの親Tranformが見つからない");
        }
    }

    public void LoadNextStage()
    {
        currentStageIndex++;

        if (currentStageIndex >= stagePrefabs.Length)
        {
            Debug.Log("すべてのステージをクリアしました！");
            return;
        }

        if (gameClearManager != null)
        {
            gameClearManager.ResetGameClear();
        }

        if (BalloonCounter.Instance != null)
        {
            BalloonCounter.Instance.ResetCounter(); // ←追加
        }

        RestartStage();
    }

}