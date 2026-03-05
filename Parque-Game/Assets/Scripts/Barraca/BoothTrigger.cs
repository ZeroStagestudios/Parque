using UnityEngine;
using UnityEngine.SceneManagement;

public class BoothTrigger : MonoBehaviour
{
    private BoothInteractable booth;
    public string snceneName;
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
                if (booth.HasPlayedToday())
                {
                    Debug.Log("Você já jogou este minigame hoje!");
                    return;
                }

                booth.RegisterPlay();
                GameManager.Instance.posicaoantesminigame = GameManager.Instance.player.transform.position;
                SceneManager.LoadScene(snceneName);

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (booth != null)
            {
               booth.ShowIndicator();
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
                booth.HideIndicator();
                mudarCena = false;
            }
        }
    }

}
