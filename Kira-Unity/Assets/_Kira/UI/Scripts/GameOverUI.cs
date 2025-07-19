using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button restartButton;
    [SerializeField] private StageManager stageManager;

    private void Awake()
    {
        gameOverUI.SetActive(false);
        restartButton.onClick.AddListener(OnRestartClicked);
    }

    public void Show()
    {
        gameOverUI.SetActive(true);
    }

    private void OnRestartClicked()
    {
        gameOverUI.SetActive(false);
        stageManager.RestartStage();
    }
}
