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

        // �{�[�����܂�������Ă��Ȃ��i�Î~�j�Ȃ�u�Z���N�g�֖߂�v
        if (!shooter.HasShot)
        {
            restartButton.SetActive(false);
            selectStageButton.SetActive(true);
        }
        else
        {
            // �����ꂽ��́A�����Ă�Ȃ烊�X�^�[�g�{�^���\���A����ȊO�͗�����\���i�܂��̓Z���N�g�ĕ\���j
            bool isMoving = ball.linearVelocity.sqrMagnitude > velocityThreshold * velocityThreshold;
            restartButton.SetActive(isMoving);
            selectStageButton.SetActive(!isMoving);
        }
    }

    public void SetBall(Rigidbody2D newBall)
    {
        ball = newBall;
        shooter = newBall.GetComponent<BallPullShooter>();

        // �����\���F�����˂Ȃ̂ŃZ���N�g�̂ݕ\��
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