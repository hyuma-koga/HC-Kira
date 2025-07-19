using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    [SerializeField] private string ballTag = "Ball";

    public void Initialize()
    {
        // 今は何も処理しないが、将来の拡張のための初期化フック
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ballTag))
        {
            BalloonCounter.Instance?.UnregisterBalloon();
            Destroy(gameObject);
        }
    }
}