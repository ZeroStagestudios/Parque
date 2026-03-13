using UnityEngine;

public class EncerrarDia : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ConfirmacaoUI.Instance.uiPanel.SetActive(true);  
        }
    }
}
