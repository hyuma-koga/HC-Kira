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
        // �@ �Q�[�����Ԃ�߂�
        Time.timeScale = 1f;

        // �A �Q�[���I�[�o�[�G�t�F�N�g���폜
        effectSpawner?.ClearEffect();

        // �B �X�v���b�V���폜
        yield return BalloonSplashEffect.ClearAllSplashesCoroutine();

        // �C UI���\��
        gameOverUI.SetActive(false);

        // �D �X�e�[�W�����X�^�[�g
        stageManager?.RestartStage();
    }
}