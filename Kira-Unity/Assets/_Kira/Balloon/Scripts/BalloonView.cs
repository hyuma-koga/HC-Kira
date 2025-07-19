using System.Collections.Generic;
using UnityEngine;

public class BalloonView : MonoBehaviour
{
    [SerializeField] private BalloonVisualStrategySO visualStrategy;

    private void Start()
    {
        if (visualStrategy == null)
        {
            Debug.LogWarning("BalloonVisualStrategySO が設定されていません。");
            return;
        }

        var sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("SpriteRenderer がアタッチされていません。");
            return;
        }

        visualStrategy.ApplyVisual(sr, transform);

        // 自身と子にある PolygonCollider2D をすべて処理
        ApplyPhysicsShapeToAllPolygonColliders(sr.sprite);

        var destroyer = GetComponent<BalloonDestroyer>();

        if (destroyer != null)
        {
            destroyer.Initialize();
        }
    }

    private void ApplyPhysicsShapeToAllPolygonColliders(Sprite sprite)
    {
        if (sprite == null) return;

        // 自身＋子オブジェクトすべての PolygonCollider2D を対象にする
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