using UnityEngine;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private GameObject             gameClearUI;
    [SerializeField] private GameObject             gameUI;
    [SerializeField] private StageManager           stageManager;
    [SerializeField] private GameClearEffectSpawner effectSpawner;

    private void Start()
    {
        gameClearUI.SetActive(false);
    }

    public void Show()
    {
        gameClearUI.SetActive(true);
    }

    public void Hide()
    {
        gameClearUI.SetActive(false);
    }

    public void NextStageButton()
    {
        Time.timeScale = 1f;
        gameUI.SetActive(true);
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());
        effectSpawner?.ClearEffects();

        if (stageManager != null)
        {
            stageManager.LoadNextStage();
        }
    }
}