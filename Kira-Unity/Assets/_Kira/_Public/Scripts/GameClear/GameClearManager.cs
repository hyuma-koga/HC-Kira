using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private GameClearUI gameClearUI;

    public void TriggerGameClear()
    {
        gameClearUI?.Show();
    }

    public void ResetGameClear()
    {
        gameClearUI.Hide();
    }
}
