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
        // ① ゲーム時間を止める
        Time.timeScale = 0f;

        // ② エフェクトは通常通り再生（TimeScale の影響を受けない）
        effectSpawner.SpawnEffects();

        // ③ 実時間で待機（タイムスケールに影響されない）
        yield return new WaitForSecondsRealtime(delayBeforeUI);

        // ④ UIを表示
        gameClearUI?.Show();
    }

    public void ResetGameClear()
    {
        gameClearUI.Hide();
    }
}