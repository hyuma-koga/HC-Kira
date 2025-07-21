using UnityEngine;
using System.Collections;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameClearUI gameClearUI;
    [SerializeField] private GameObject  gameUI;
    [SerializeField] private GameClearEffectSpawner effectSpawner;
    [SerializeField] private float delayBeforeUI = 3f;

    public void TriggerGameClear()
    {
        StartCoroutine(PlayClearSequence());
    }

    private IEnumerator PlayClearSequence()
    {
        gameUI.SetActive(false);
        Time.timeScale = 0f;

        effectSpawner.SpawnEffects();

        yield return new WaitForSecondsRealtime(delayBeforeUI);

        gameClearUI?.Show();
    }

    public void ResetGameClear()
    {
        gameClearUI.Hide();
    }
}