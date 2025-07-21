using UnityEngine;

public class GameOverEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private string     ballTag = "Ball";

    private GameObject                  spawnedEffect;

    public void SpawnEffect(Transform ballTransform)
    {
        ClearEffect();

        GameObject ballObj = GameObject.FindWithTag(ballTag);

        if (ballObj != null)
        {
            spawnedEffect = Instantiate(effectPrefab, ballObj.transform.position, Quaternion.identity);
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