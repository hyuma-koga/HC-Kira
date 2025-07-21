using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] private GameObject   titleUI;
    [SerializeField] private GameObject   stageSelectUI;
    [SerializeField] private GameObject   gameUI;
    [SerializeField] private StageManager stageManager;

    public void OnStageButtonPressed(int index)
    {
        stageManager.LoadStage(index);
        stageSelectUI.SetActive(false);
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        StartCoroutine(BalloonSplashEffect.ClearAllSplashesCoroutine());
    }

    public void OnBackButtonPressed()
    {
        stageSelectUI.SetActive(false);
        titleUI.SetActive(true);
    }
}
