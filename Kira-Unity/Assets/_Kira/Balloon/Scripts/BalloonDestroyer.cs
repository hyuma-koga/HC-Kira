using UnityEngine;

public class BalloonDestroyer : MonoBehaviour
{
    [SerializeField] private string ballTag = "Ball";

    public void Initialize()
    {
        // ���͉����������Ȃ����A�����̊g���̂��߂̏������t�b�N
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ballTag))
        {
            BalloonCounter.Instance?.UnregisterBalloon();
            Destroy(gameObject);
        }
    }
}