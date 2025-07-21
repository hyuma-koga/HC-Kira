using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private StageManager stageManager;

    private void Awake()
    {
        gameOverUI.SetActive(false);
        restartButton.onClick.AddListener(OnRestartClicked);
    }

    public void Show()
    {
        gameOverUI.SetActive(true);
    }

    private void OnRestartClicked()
    {
        StartCoroutine(HandleRestartSequence());
    }

    private IEnumerator HandleRestartSequence()
    {
        // スプラッシュ削除（内部で yield return null ＆ WaitUntil）
        yield return BalloonSplashEffect.ClearAllSplashesCoroutine();

        // GameOverUI 非表示
        gameOverUI.SetActive(false);

        // ステージリスタート
        stageManager.RestartStage();
    }

}
