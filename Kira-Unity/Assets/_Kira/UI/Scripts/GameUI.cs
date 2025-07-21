using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject selectStageButton;
    [SerializeField] private float velocityThreshold = 0.05f;

    private Rigidbody2D ball;
    private BallPullShooter shooter;

    private void Update()
    {
        if (ball == null || shooter == null) return;

        // ボールがまだ撃たれていない（静止）なら「セレクトへ戻る」
        if (!shooter.HasShot)
        {
            restartButton.SetActive(false);
            selectStageButton.SetActive(true);
        }
        else
        {
            // 撃たれた後は、動いてるならリスタートボタン表示、それ以外は両方非表示（またはセレクト再表示）
            bool isMoving = ball.linearVelocity.sqrMagnitude > velocityThreshold * velocityThreshold;
            restartButton.SetActive(isMoving);
            selectStageButton.SetActive(!isMoving);
        }
    }

    public void SetBall(Rigidbody2D newBall)
    {
        ball = newBall;
        shooter = newBall.GetComponent<BallPullShooter>();

        // 初期表示：未発射なのでセレクトのみ表示
        restartButton.SetActive(false);
        selectStageButton.SetActive(true);
    }

    public void OnSelectStageButtonPressed()
    {
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());

        if (StageManager.Instance != null)
        {
            StageManager.Instance.ReturnToStageSelect();
        }
    }

    public void OnRestartButtonPressed()
    {
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());

        if (StageManager.Instance != null)
        {
            StageManager.Instance.RestartStage();
        }
    }
}