using UnityEngine;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private StageManager stageManager;
    [SerializeField] private GameClearEffectSpawner effectSpawner; // ← 追加

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
        // ① ゲーム時間を戻す
        Time.timeScale = 1f;

        // ② スプラッシュ削除
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());

        // ③ エフェクト削除
        effectSpawner?.ClearEffects();

        // ④ ステージ切り替え
        if (stageManager != null)
        {
            stageManager.LoadNextStage();
        }
        else
        {
            Debug.LogWarning("StageManager が設定されていません");
        }
    }

}
