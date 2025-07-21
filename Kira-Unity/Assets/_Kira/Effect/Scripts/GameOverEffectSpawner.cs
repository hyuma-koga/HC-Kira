using UnityEngine;

public class GameOverEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private string ballTag = "Ball"; // Ç‹ÇΩÇÕñºëO "Ball" Ç…ïœÇ¶ÇƒÇ‡OK
    private GameObject spawnedEffect;

    public void SpawnEffect(Transform ballTransform)
    {
        ClearEffect();

        GameObject ballObj = GameObject.FindWithTag(ballTag);
        if (ballObj != null)
        {
            spawnedEffect = Instantiate(effectPrefab, ballObj.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Ball Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÇ≈ÇµÇΩÅitag = " + ballTag + "Åj");
        }
    }

    public void ClearEffect()
    {
        if (spawnedEffect != null)
        {
            Destroy(spawnedEffect);
            spawnedEffect = null;
        }
    }
}
