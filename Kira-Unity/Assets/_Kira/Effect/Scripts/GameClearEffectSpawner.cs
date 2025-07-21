using UnityEngine;
using System.Collections.Generic;

public class GameClearEffectSpawner : MonoBehaviour
{
    [Header("�G�t�F�N�g��Prefab")]
    [SerializeField] private GameObject effectPrefab;

    [Header("�����ʒu�iTransform��3�j")]
    [SerializeField] private Transform[] spawnPoints;

    private List<GameObject> spawnedEffects = new List<GameObject>();

    public void SpawnEffects()
    {
        ClearEffects(); // �O�̂��ߎ��O�ɍ폜�i���d�����h�~�j

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