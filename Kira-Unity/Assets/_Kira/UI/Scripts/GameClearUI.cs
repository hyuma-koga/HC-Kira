using UnityEngine;

public class GameClearUI : MonoBehaviour
{
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private StageManager stageManager;
    [SerializeField] private GameClearEffectSpawner effectSpawner; // �� �ǉ�

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
        // �@ �Q�[�����Ԃ�߂�
        Time.timeScale = 1f;

        // �A �X�v���b�V���폜
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());

        // �B �G�t�F�N�g�폜
        effectSpawner?.ClearEffects();

        // �C �X�e�[�W�؂�ւ�
        if (stageManager != null)
        {
            stageManager.LoadNextStage();
        }
        else
        {
            Debug.LogWarning("StageManager ���ݒ肳��Ă��܂���");
        }
    }

}
