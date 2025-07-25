using UnityEngine;
using System.Collections.Generic;

public class GameClearEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject  effectPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private List<GameObject>             spawnedEffects = new List<GameObject>();

    public void SpawnEffects()
    {
        ClearEffects();

        foreach (var point in spawnPoints)
        {
            if (point != null)
            {
                var effect = Instantiate(effectPrefab, point.position, Quaternion.identity);
                spawnedEffects.Add(effect);
            }
        }
    }

    public void ClearEffects()
    {
        foreach (var effect in spawnedEffects)
        {
            if (effect != null)
            {
                Destroy(effect);
            }
        }

        spawnedEffects.Clear();
    }
}