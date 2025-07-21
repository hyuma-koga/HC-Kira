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
        // �X�v���b�V���폜�i������ yield return null �� WaitUntil�j
        yield return BalloonSplashEffect.ClearAllSplashesCoroutine();

        // GameOverUI ��\��
        gameOverUI.SetActive(false);

        // �X�e�[�W���X�^�[�g
        stageManager.RestartStage();
    }

}
