using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float maxDragDistance = 3f;

    private BallPullShooter        shooter;
    private BallDragLine           dragLine;
    private Vector2                dragStartPos;
    private Vector2                dragVector;
    private bool                   isDragging = false;

    private void Awake()
    {
        shooter = GetComponent<BallPullShooter>();
        dragLine = GetComponent<BallDragLine>();
    }

    private void OnMouseDown()
    {
        if (shooter.HasShot)
        {
            return;
        }

        isDragging = true;
        dragStartPos = GetMouseWorldPos();
        dragLine.Show();
    }

    private void OnMouseDrag()
    {
        if (!isDragging)
        {
            return;
        }

        Vector2 current = GetMouseWorldPos();
        dragVector = Vector2.ClampMagnitude(dragStartPos - current, maxDragDistance);
        dragLine.UpdateLine(transform.position, dragVector);
    }

    private void OnMouseUp()
    {
        if (!isDragging)
        {
            return;
        }

        isDragging = false;
        dragLine.Hide();
        shooter.Shoot(dragVector);
    }

    private Vector2 GetMouseWorldPos()
    {
        var screenPos = Input.mousePosition;
        screenPos.z = Mathf.Abs(Camera.main.transform.position.z);
        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}