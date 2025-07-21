using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject selectStageButton;
    [SerializeField] private Text       stageText;
    [SerializeField] private float      velocityThreshold = 0.05f;

    private Rigidbody2D                 rb_Ball;
    private BallPullShooter             shooter;

    private void Update()
    {
        if (rb_Ball == null || shooter == null) return;

        if (!shooter.HasShot)
        {
            restartButton.SetActive(false);
            selectStageButton.SetActive(true);
        }
        else
        {
            bool isMoving = rb_Ball.linearVelocity.sqrMagnitude > velocityThreshold * velocityThreshold;
            restartButton.SetActive(isMoving);
            selectStageButton.SetActive(!isMoving);
        }
    }

    public void SetBall(Rigidbody2D newBall)
    {
        rb_Ball = newBall;
        shooter = newBall.GetComponent<BallPullShooter>();

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

    public void UpdateStageNumber(int stageIndex)
    {
        stageText.text = $"{stageIndex + 1}";
    }
}