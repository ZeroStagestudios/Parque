using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoothTrigger : MonoBehaviour
{
    private BoothInteractable booth;
    public string snceneName;
    public bool mudarCena = false;
    private IndicatorShake indicatorShake;
    void Awake()
    {
        booth = GetComponentInParent<BoothInteractable>();
        indicatorShake = booth.indicador.GetComponent<IndicatorShake>();
    }
    void Update()
    {   
        if(mudarCena)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {   if(!GameManager.Instance.CanPlayMinigame() || booth.HasPlayedToday())
                {
                    //Colocar Som !!!!
                    indicatorShake.Shake();
                    return;
                }
                booth.RegisterPlay();
                GameManager.Instance.RegisterMinigamePlayed();
                GameManager.Instance.posicaoantesminigame = GameManager.Instance.player.transform.position;
                StartCoroutine(TransitionToMinigame());
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

    public IEnumerator TransitionToMinigame()
    {
        FadeController.Instance.StartFadeOut(1f);
        yield return new WaitForSeconds(1f); 
        SceneManager.LoadScene(snceneName);
    }

}
