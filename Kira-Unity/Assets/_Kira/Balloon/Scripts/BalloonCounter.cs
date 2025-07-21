using UnityEngine;

public class BalloonCounter : MonoBehaviour
{
    [SerializeField] private GameClearManager gameClearManager;
    public static BalloonCounter Instance { get; private set; }
    private int balloonCount;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterBalloon(Transform balloonRoot)
    {
        ResetCounter();

        foreach (Transform child in balloonRoot)
        {
            if (child.GetComponentInChildren<BalloonDestroyer>() != null)
            {
                balloonCount++;
            }
        }
    }

    public void UnregisterBalloon()
    {
        balloonCount--;

        if (balloonCount <= 0)
        {
            gameClearManager.TriggerGameClear();
        }
    }

    public void ResetCounter()
    {
        balloonCount = 0;
    }
}