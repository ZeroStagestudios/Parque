using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
   private float tempoMinigame = 40f;
   int ultimosegundo = 40;

   private int patoAcertado = 0;
   private int patoParaAcertar = 15;
   bool jogoFinalizado = false;
   FadeController fadeController;
   public CharacterController playerController;
   HUDManager hudManager;

    void Start()
    {
        fadeController = FadeController.Instance;   
        hudManager = FindFirstObjectByType<HUDManager>();
        playerController = FindFirstObjectByType<CharacterController>(); 
    }

    void Update()
    {   
        if(jogoFinalizado)
        {
            return;
        }
        tempoMinigame -= Time.deltaTime;
        int segundoAtual = Mathf.FloorToInt(tempoMinigame);
        if (segundoAtual != ultimosegundo)
        {
            ultimosegundo = segundoAtual;
            hudManager.AtualizarTempo(ultimosegundo);
        }
        if (tempoMinigame <= 0){
            StartCoroutine(FinalizarMinigame());           
        }
      
    }

    public void Patoacertado()
    {
        patoAcertado++;       
        hudManager.AtualizarPatos(patoAcertado);
    }
    void Venceu()
    {
        Debug.Log("Você venceu o minigame!");
    }
    void Perdeu()
    {
        Debug.Log("Você perdeu o minigame!");
    }
    public void AtualizarMunicao(int municao)
    {
        hudManager.AtualizarMunicao(municao);
    }
    
IEnumerator FinalizarMinigame()
    {
        jogoFinalizado = true;
        fadeController.StartFadeOut(2f);
        if(patoAcertado >= patoParaAcertar)Venceu();
        else Perdeu();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuPrincipal");            
    }

}
