using System.Collections.Generic;
using UnityEngine;

public class BalloonView : MonoBehaviour
{
    [SerializeField] private BalloonVisualStrategySO visualStrategy;
    [SerializeField] private int                     spriteIndex;

    public BalloonVisualStrategySO                   VisualStrategy => visualStrategy;
    public int                                       SpriteIndex => spriteIndex;

    private void Start()
    {
        if (visualStrategy == null)
        {
            return;
        }

        var sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            return;
        }

        visualStrategy.ApplyVisual(sr, transform);

        ApplyPhysicsShapeToAllPolygonColliders(sr.sprite);

        var destroyer = GetComponent<BalloonDestroyer>();

        if (destroyer != null)
        {
            destroyer.Initialize();
        }
    }

    public void SetSpriteIndex(int index)
    {
        spriteIndex = index;
    }

    private void ApplyPhysicsShapeToAllPolygonColliders(Sprite sprite)
    {
        if (sprite == null)
        {
            return;
        }

        PolygonCollider2D[] colliders = GetComponentsInChildren<PolygonCollider2D>();

        foreach (var collider in colliders)
        {
            collider.pathCount = sprite.GetPhysicsShapeCount();
            var path = new List<Vector2>();

            for (int i = 0; i < collider.pathCount; i++)
            {
                path.Clear();
                sprite.GetPhysicsShape(i, path);
                collider.SetPath(i, path);
            }
        }
    }
}