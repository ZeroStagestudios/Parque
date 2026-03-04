using UnityEngine;
using UnityEngine.SceneManagement;

public class BoothTrigger : MonoBehaviour
{
    private BoothInteractable booth;
    public bool mudarCena = false;
    void Awake()
    {
        booth = GetComponentInParent<BoothInteractable>();
    }
    void Update()
    {   
        if(mudarCena)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // checar se jogador já jogou hoje antes de carregar a cena
                SceneManager.LoadScene("tiro ao alvo");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (booth != null)
            {
               BoothUIManager.Instance.ShowIndicator();
               mudarCena = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (booth != null)
            {
                BoothUIManager.Instance.HideIndicator();
                mudarCena = false;
            }
        }
    }

}
