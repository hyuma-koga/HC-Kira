using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    [SerializeField] private string     ballTag = "Ball";
    [SerializeField] private GameObject splashPrefab;

    public void Initialize()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(ballTag))
        {
            return;
        }

        var view = GetComponent<BalloonView>();

        if (view != null && splashPrefab != null)
        {
            Sprite splashSprite = view.VisualStrategy.GetSplashSprite(view.SpriteIndex);
            if (splashSprite != null)
            {
                GameObject splash = Instantiate(splashPrefab, transform.position, Quaternion.identity);
                var sr = splash.GetComponent<SpriteRenderer>();
                if (sr != null) sr.sprite = splashSprite;
            }
        }

        BalloonCounter.Instance?.UnregisterBalloon();
        Destroy(gameObject);
    }
}