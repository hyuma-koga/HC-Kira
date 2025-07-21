using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BalloonSplashEffect : MonoBehaviour
{
    private static List<GameObject> activeSplashes = new List<GameObject>();

    public static IEnumerator ClearAllSplashesCoroutine()
    {
        List<BalloonSplashEffect> splashes = new List<BalloonSplashEffect>(Object.FindObjectsByType<BalloonSplashEffect>(FindObjectsSortMode.None));

        foreach (var splash in splashes)
        {
            if (splash != null)
            {
                Debug.Log($"�X�v���b�V���폜���N�G�X�g: {splash.name}");
                Object.Destroy(splash.gameObject);
            }
        }

        activeSplashes.Clear();

        // Destroy ���������� OnDestroy() ���Ă΂��܂ő҂�
        yield return new WaitUntil(() =>
            Object.FindFirstObjectByType<BalloonSplashEffect>() == null &&
            splashes.TrueForAll(s => s == null)
        );

        Debug.Log("�X�v���b�V�����S�폜����");
    }
    public void Initialize(Sprite sprite)
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null && sprite != null)
        {
            sr.sprite = sprite;
        }

        activeSplashes.Add(gameObject);
        Debug.Log("�X�v���b�V���ǉ�: " + gameObject.name);
    }

    private void OnDestroy()
    {
        Debug.Log("�X�v���b�V���폜: " + gameObject.name);
        activeSplashes.Remove(gameObject);
    }

}
