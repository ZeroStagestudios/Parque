using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ResultadoMinigameController : MonoBehaviour
{
    public Animator animator;
    public TMP_Text txtResultado;
    public Transform containterDados;
    public GameObject linhaPrefab;
    
    public float tempoAnimacao = 3f;
    public AudioClip somVitoria; 
    public AudioClip somDerrota;

    
     void Awake()
    {
        animator =  GetComponentInChildren<Animator>();
        
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        StartCoroutine(TransitionToParque());  
    }
    public IEnumerator TransitionToParque()
    {
        if(GameManager.Instance.resultadoMinigame == GameManager.ResultadoMinigame.Vitoria)
        {
           if(animator != null) animator.SetTrigger("Vitoria");

           txtResultado.text = "Vitoria"; 
        } 
        else
        {
           if(animator != null) animator.SetTrigger("Derrota");
            txtResultado.text = "Derrota";
        }
        PreencherRelatorio();
        yield return new WaitForSeconds(tempoAnimacao);
       
    }
    public void BtnVoltar()
    {
        StartCoroutine(Voltar());
    }
    public IEnumerator Voltar()
    {       
            yield return FadeController.Instance.StartFadeOut(2f);
            SceneManager.LoadScene("Parque");
    }

    public void PreencherRelatorio()
    {
        foreach(KeyValuePair<string, string> item in GameManager.Instance.dadosRelatorio)
        {
            GameObject linha = Instantiate(linhaPrefab, containterDados);
            TMP_Text txt = linha.GetComponent<TMP_Text>();
            txt.text = item.Key + ": " + item.Value;
        }
    }
}
