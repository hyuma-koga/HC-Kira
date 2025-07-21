using UnityEngine;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private StageManager stageManager;

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
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());

        if (stageManager != null)
        {
            stageManager.LoadNextStage();
        }
        else
        {
            Debug.LogWarning("StageManager Ç™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
        }
    }
}
