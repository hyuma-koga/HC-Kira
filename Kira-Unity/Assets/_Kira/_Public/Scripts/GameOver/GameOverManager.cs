using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameOverUI            gameOverUI;
    [SerializeField] private GameObject            gameUI;
    [SerializeField] private string                ballTag = "Ball";
    [SerializeField] private float                 bottomY = -10f;
    [SerializeField] private float                 leftX = -10f;
    [SerializeField] private float                 rightX = 10f;
    [SerializeField] private GameOverEffectSpawner effectSpawner;
    [SerializeField] private float                 delayBeforeUI = 3f;

    private GameObject                             ball;
    private bool                                   isGameOver = false;

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (ball == null)
        {
            ball = GameObject.FindWithTag(ballTag);
            return;
        }

        Vector2 pos = ball.transform.position;

        if (pos.y < bottomY || pos.x < leftX || pos.x > rightX)
        {
            StartCoroutine(PlayGameOverSequence());
        }
    }

    private IEnumerator PlayGameOverSequence()
    {
        isGameOver = true;

        gameUI.SetActive(false);

        Time.timeScale = 0f;

        if (ball != null && effectSpawner != null)
        {
            effectSpawner.SpawnEffect(ball.transform);
        }

        yield return new WaitForSecondsRealtime(delayBeforeUI);

        gameOverUI?.Show();
    }

    public void ResetGameOver()
    {
        isGameOver = false;
        ball = null;
    }
}