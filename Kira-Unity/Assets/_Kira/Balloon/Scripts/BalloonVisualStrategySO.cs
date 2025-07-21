using UnityEngine;

[CreateAssetMenu(fileName = "BalloonVisualStrategy", menuName = "Balloon/BisualStrategy", order = 0)]
public class BalloonVisualStrategySO : ScriptableObject
{
    public BalloonSize size;
    public Sprite[]    sprites;
    public Sprite[]    splashSprites;
    public float       scale = 1f;

    public void ApplyVisual(SpriteRenderer renderer, Transform targetTransform)
    {
        if (renderer != null && sprites != null && sprites.Length > 0)
        {
            int index = Random.Range(0, sprites.Length);
            renderer.sprite = sprites[index];
            renderer.gameObject.GetComponent<BalloonView>().SetSpriteIndex(index);  
        }

        if (targetTransform != null)
        {
            targetTransform.localScale = Vector3.one * scale;
        }
    }

    public Sprite GetSplashSprite(int index)
    {
        if (splashSprites != null && splashSprites.Length > 0)
        {
            int i = Mathf.Clamp(index, 0, splashSprites.Length - 1);
            return splashSprites[i];
        }
        return null;
    }
}
