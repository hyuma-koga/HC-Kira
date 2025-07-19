using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private string     ballTag = "Ball";
    [SerializeField] private float      bottomY = -10f;
    [SerializeField] private float      leftX = -10f;
    [SerializeField] private float      rightX = 10f;
    
    private GameObject                  ball;
    private bool                        isGameOver = false;

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
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        if (gameOverUI != null)
        {
            gameOverUI.Show();
        }
    }

    public void ResetGameOver()
    {
        isGameOver = false;
        ball = null;
    }
}
