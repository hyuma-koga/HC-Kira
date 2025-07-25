using UnityEngine;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject stageSelectUI;

    public void OnStartButtonPressed()
    {
        titleUI.SetActive(false);
        stageSelectUI.SetActive(true);
    }
}