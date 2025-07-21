using UnityEngine;

public class BallPullShooter : MonoBehaviour
{
    [SerializeField] private float power = 10f;

    public bool                    HasShot { get; private set; } = false;
    private Rigidbody2D            rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    public void Shoot(Vector2 direction)
    {
        if (HasShot)
        {
            return;
        }

        HasShot = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.linearVelocity = direction * power;
    }
}