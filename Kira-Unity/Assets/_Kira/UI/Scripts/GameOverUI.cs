using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
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
        gameOverUI.SetActive(true);
    }

    private void OnRestartClicked()
    {
        StartCoroutine(HandleRestartSequence());
    }

    private IEnumerator HandleRestartSequence()
    {
        // ① ゲーム時間を戻す
        Time.timeScale = 1f;

        // ② ゲームオーバーエフェクトを削除
        effectSpawner?.ClearEffect();

        // ③ スプラッシュ削除
        yield return BalloonSplashEffect.ClearAllSplashesCoroutine();

        // ④ UIを非表示
        gameOverUI.SetActive(false);

        // ⑤ ステージをリスタート
        stageManager?.RestartStage();
    }
}