using UnityEngine;
using System.Collections;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameClearUI gameClearUI;
    [SerializeField] private GameClearEffectSpawner effectSpawner;
    [SerializeField] private float delayBeforeUI = 3f;

    public void TriggerGameClear()
    {
        StartCoroutine(PlayClearSequence());
    }

    private IEnumerator PlayClearSequence()
    {
        // �@ �Q�[�����Ԃ��~�߂�
        Time.timeScale = 0f;

        // �A �G�t�F�N�g�͒ʏ�ʂ�Đ��iTimeScale �̉e�����󂯂Ȃ��j
        effectSpawner.SpawnEffects();

        // �B �����Ԃőҋ@�i�^�C���X�P�[���ɉe������Ȃ��j
        yield return new WaitForSecondsRealtime(delayBeforeUI);

        // �C UI��\��
        gameClearUI?.Show();
    }

    public void ResetGameClear()
    {
        gameClearUI.Hide();
    }
}