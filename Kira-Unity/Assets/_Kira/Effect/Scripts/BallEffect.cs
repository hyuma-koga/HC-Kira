using UnityEngine;
using System.Collections;

public class BallEffect : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;     // 残像のプレハブ（SpriteRenderer付き）
    [SerializeField] private float spawnInterval = 0.02f; // 生成間隔
    [SerializeField] private float velocityThreshold = 0.1f; // 動いているとみなす速度
    [SerializeField] private float ghostLifetime = 0.3f;  // 残像の寿命

    private Rigidbody2D rb;
    private bool isSpawning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.linearVelocity.magnitude > velocityThreshold)
        {
            if (!isSpawning)
            {
                StartCoroutine(SpawnGhosts());
            }
        }
    }

    private IEnumerator SpawnGhosts()
    {
        isSpawning = true;

        while (rb.linearVelocity.magnitude > velocityThreshold)
        {
            GameObject ghost = Instantiate(ghostPrefab, transform.position, transform.rotation);
            SpriteRenderer sr = ghost.GetComponent<SpriteRenderer>();
            SpriteRenderer ballSR = GetComponent<SpriteRenderer>();

            if (sr != null && ballSR != null)
            {
                sr.sprite = ballSR.sprite;
                sr.color = new Color(1, 1, 1, 0.5f); // 半透明
                sr.sortingLayerID = ballSR.sortingLayerID;
                sr.sortingOrder = ballSR.sortingOrder - 1;
            }

            Destroy(ghost, ghostLifetime);
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }
}