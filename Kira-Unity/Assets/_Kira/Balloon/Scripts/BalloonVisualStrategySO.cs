using UnityEngine;

[CreateAssetMenu(fileName = "BalloonVisualStrategy", menuName = "Balloon/BisualStrategy", order = 0)]
public class BalloonVisualStrategySO : ScriptableObject
{
    public BalloonSize size;
    public Sprite[]    sprites;
    public float       scale = 1f;

    public void ApplyVisual(SpriteRenderer renderer, Transform targetTransform)
    {
        if (renderer != null && sprites != null && sprites.Length > 0)
        {
            renderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }

        if (targetTransform != null)
        {
            targetTransform.localScale = Vector3.one * scale;
        }
    }
}
