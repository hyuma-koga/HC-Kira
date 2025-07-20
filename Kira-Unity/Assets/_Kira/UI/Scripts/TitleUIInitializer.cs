using UnityEngine;

public class TitleUIInitializer : MonoBehaviour
{
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject stageSelectUI;
    [SerializeField] private Transform stageParent;

    private void Start()
    {
        if (titleUI != null)
        {
            titleUI.SetActive(true);
        }

        if (stageSelectUI != null)
        {

            stageSelectUI.SetActive(false);
        }

        if (stageParent != null && stageParent.childCount > 0)
        {
            foreach (Transform child in stageParent)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
