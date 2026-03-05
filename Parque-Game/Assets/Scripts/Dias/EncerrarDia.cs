using UnityEngine;

public class EncerrarDia : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
            Debug.Log("Trigger acionado por: " + other.name);

        if (other.CompareTag("Player"))
        {
            ConfirmacaoUI.Instance.uiPanel.SetActive(true);  
            Debug.Log("Painel ativado: " + ConfirmacaoUI.Instance.uiPanel.activeSelf);          
        }
    }
}
