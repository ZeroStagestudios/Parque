using UnityEngine;

public class BoothUIManager : MonoBehaviour
{
    public GameObject uiPanel; 
    public static BoothUIManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShowIndicator ()
    {
        uiPanel.SetActive(true);
    }

    public void HideIndicator ()
    {
        uiPanel.SetActive(false);
    }
}
