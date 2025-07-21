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

        //Note: 各BalloonSplashEffectのGameObjectを破壊する
        foreach (var splash in splashes)
        {
            if (splash != null)
            {
                Object.Destroy(splash.gameObject);
            }
        }

        activeSplashes.Clear();

        //Note: BalloonSplashEffectが全て削除されるまで待機する
        yield return new WaitUntil(() =>
        {
            //Note: シーン上にBalloonSplashEffectが1つも存在しないか
            bool noSplashInScene = Object.FindFirstObjectByType<BalloonSplashEffect>() == null;

            //Note: 取得したリスト内のすべての参照が削除済みになっているか
            bool allSplashesDestroyed = splashes.TrueForAll(s => s == null);

            //Note: 両方の条件が満たされたら完了
            return noSplashInScene && allSplashesDestroyed;
        });
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