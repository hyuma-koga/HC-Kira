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

        //Note: �eBalloonSplashEffect��GameObject��j�󂷂�
        foreach (var splash in splashes)
        {
            if (splash != null)
            {
                Object.Destroy(splash.gameObject);
            }
        }

        activeSplashes.Clear();

        //Note: BalloonSplashEffect���S�č폜�����܂őҋ@����
        yield return new WaitUntil(() =>
        {
            //Note: �V�[�����BalloonSplashEffect��1�����݂��Ȃ���
            bool noSplashInScene = Object.FindFirstObjectByType<BalloonSplashEffect>() == null;

            //Note: �擾�������X�g���̂��ׂĂ̎Q�Ƃ��폜�ς݂ɂȂ��Ă��邩
            bool allSplashesDestroyed = splashes.TrueForAll(s => s == null);

            //Note: �����̏������������ꂽ�犮��
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