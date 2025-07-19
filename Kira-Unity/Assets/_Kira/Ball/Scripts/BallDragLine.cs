using UnityEngine;

public class BallDragLine : MonoBehaviour
{
    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
        line.useWorldSpace = true;
    }

    public void Show()
    {
        line.enabled = true;
    }

    public void UpdateLine(Vector2 origin, Vector2 direction)
    {
        line.SetPosition(0, origin);
        line.SetPosition(1, origin + direction);
    }

    public void Hide()
    {
        line.enabled = false;
    }
}