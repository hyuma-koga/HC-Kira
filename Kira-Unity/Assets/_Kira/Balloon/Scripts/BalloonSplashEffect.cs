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
                Object.Destroy(splash.gameObject);
            }
        }

        activeSplashes.Clear();

        yield return new WaitUntil(() =>
            Object.FindFirstObjectByType<BalloonSplashEffect>() == null &&
            splashes.TrueForAll(s => s == null)
        );
    }
    public void Initialize(Sprite sprite)
    {
        var sr = GetComponent<SpriteRenderer>();

        if (sr != null && sprite != null)
        {
            sr.sprite = sprite;
        }

        activeSplashes.Add(gameObject);
    }

    private void OnDestroy()
    {
        activeSplashes.Remove(gameObject);
    }
}