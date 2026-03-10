using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultadoMinigameController : MonoBehaviour
{
    public Animator animator;
    public float tempoAnimacao = 3f;
    public AudioClip somVitoria;
    public AudioClip somDerrota;
     void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        StartCoroutine(TransitionToParque());  
    }
    public IEnumerator TransitionToParque()
    {
        if(GameManager.Instance.resultadoMinigame == GameManager.ResultadoMinigame.Vitoria) animator.SetTrigger("Vitoria"); 
        else animator.SetTrigger("Derrota");   
        yield return new WaitForSeconds(tempoAnimacao);
        FadeController.Instance.StartFadeOut(2f);
        yield return new WaitForSeconds(2f); 
        SceneManager.LoadScene("Parque");
    }
}
