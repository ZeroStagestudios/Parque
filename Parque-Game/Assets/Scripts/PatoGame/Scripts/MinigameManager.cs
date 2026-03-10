using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour, IMinigameManager
{
   private float tempoMinigame = 40f;
   int ultimosegundo = 40;

   private int patoAcertado = 0;
   int tirosUsados = 0;
   private int patoParaAcertar = 15;
   bool jogoFinalizado = false;
   FadeController fadeController;
   public CharacterController playerController;
   HUDManager hudManager;
    [SerializeField] private int ticketsGanhosMinigame = 10;
    public int ticketsGanhos { get => ticketsGanhosMinigame; set => ticketsGanhosMinigame = value; }

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
    public void AtualizarMunicao(int municao)
    {
        hudManager.AtualizarMunicao(municao);
        tirosUsados++;
    }    
IEnumerator FinalizarMinigame()
    {
        jogoFinalizado = true;
        fadeController.StartFadeOut(2f);
        DadosMinigame();
        if(patoAcertado >= patoParaAcertar) vencerMinigame();
        else perderMinigame();
        yield return new WaitForSeconds(2f);                  
        SceneManager.LoadScene("ResultadoMinigame");
    }

    public void vencerMinigame()
    {
        GameManager.Instance.resultadoMinigame = GameManager.ResultadoMinigame.Vitoria;
        GameManager.Instance.totalTickets += ticketsGanhos;
        GameManager.Instance.totalMinigamesVencidos++;
    }

    public void perderMinigame()
    {
        GameManager.Instance.resultadoMinigame = GameManager.ResultadoMinigame.Derrota;
    }
    public void DadosMinigame()
    {
        GameManager.Instance.dadosRelatorio = new Dictionary<string, string>();
        GameManager.Instance.dadosRelatorio.Add("Minigame", "PatoGame");
        GameManager.Instance.dadosRelatorio.Add("Patos Acertados", patoAcertado.ToString());
        GameManager.Instance.dadosRelatorio.Add("Precisão", patoAcertado > 0 ? (patoAcertado * 100 / tirosUsados ).ToString() + "%" : "0%");
    }

  
}
