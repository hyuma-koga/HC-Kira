using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private AudioClip bounceClip;
    [SerializeField] private float     maxDragDistance = 3f;
    [SerializeField] private float     minBounceVelocity = 0.5f;

    private BallPullShooter            shooter;
    private BallDragLine               dragLine;
    private AudioSource                audioSource;
    private Vector2                    dragStartPos;
    private Vector2                    dragVector;
    private bool                       isDragging = false;

    private void Awake()
    {
        shooter = GetComponent<BallPullShooter>();
        dragLine = GetComponent<BallDragLine>();
        audioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impact = collision.relativeVelocity.magnitude;

        if (impact >= minBounceVelocity && bounceClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(bounceClip);
        }
    }
}