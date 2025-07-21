using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private StageManager stageManager;
    [SerializeField] private GameOverEffectSpawner effectSpawner;

    private void Awake()
    {
        gameOverUI.SetActive(false);
        restartButton.onClick.AddListener(OnRestartClicked);
    }

    public void Show()
    {
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    private void OnRestartClicked()
    {
        StartCoroutine(HandleRestartSequence());
    }

    private IEnumerator HandleRestartSequence()
    {
        Time.timeScale = 1f;

        effectSpawner?.ClearEffect();

        yield return BalloonSplashEffect.ClearAllSplashesCoroutine();

        gameOverUI.SetActive(false);
        gameUI.SetActive(true);

        stageManager?.RestartStage();
    }
}