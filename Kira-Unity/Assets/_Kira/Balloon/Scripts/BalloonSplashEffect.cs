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
                Debug.Log($"スプラッシュ削除リクエスト: {splash.name}");
                Object.Destroy(splash.gameObject);
            }
        }

        activeSplashes.Clear();

        // Destroy が完了して OnDestroy() が呼ばれるまで待つ
        yield return new WaitUntil(() =>
            Object.FindFirstObjectByType<BalloonSplashEffect>() == null &&
            splashes.TrueForAll(s => s == null)
        );

        Debug.Log("スプラッシュ完全削除完了");
    }
    public void Initialize(Sprite sprite)
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null && sprite != null)
        {
            sr.sprite = sprite;
        }

        activeSplashes.Add(gameObject);
        Debug.Log("スプラッシュ追加: " + gameObject.name);
    }

    private void OnDestroy()
    {
        Debug.Log("スプラッシュ削除: " + gameObject.name);
        activeSplashes.Remove(gameObject);
    }

}
