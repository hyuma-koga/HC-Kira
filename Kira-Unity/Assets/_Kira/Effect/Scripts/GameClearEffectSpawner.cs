using UnityEngine;
using System.Collections.Generic;

public class GameClearEffectSpawner : MonoBehaviour
{
    [Header("エフェクトのPrefab")]
    [SerializeField] private GameObject effectPrefab;

    [Header("生成位置（Transformを3つ）")]
    [SerializeField] private Transform[] spawnPoints;

    private List<GameObject> spawnedEffects = new List<GameObject>();

    public void SpawnEffects()
    {
        ClearEffects(); // 念のため事前に削除（多重発生防止）

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