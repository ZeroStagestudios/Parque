using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int dia = 1;
    public static GameManager Instance;
    public GameObject player;
    public Transform posicaoInicial;
    public Vector3 posicaoantesminigame;
    private int minigamesJogadosHoje = 0;
    private int maxMinigamesPorDia = 4;
    private CharacterController characterController;

    public Dictionary<string, string> dadosRelatorio;

    public enum ResultadoMinigame{Vitoria, Derrota}
    public ResultadoMinigame resultadoMinigame;
    public int totalTickets;
    public int totalMinigamesVencidos;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject); 
        NewGame();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posicaoInicial = GameObject.FindGameObjectWithTag("Respawn")?.transform;
        if (player!= null)
        {
            characterController = player.GetComponent<CharacterController>();

            if(posicaoantesminigame != Vector3.zero)
            {
               Posicaominigame();
            }else
            {
               player.transform.position = posicaoInicial.position;
            }
        }
        FadeController.Instance.StartFadeIn(1f);
    }
    void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }   

    public void NextDay()
    {
        dia++;
        characterController.enabled = false; 
        player.transform.position = posicaoInicial.position; 
        characterController.enabled = true; 
        if (dia > 5)
        {
            //Fim do jogo
            return;
        }  
        minigamesJogadosHoje = 0;     
    }

    public void Posicaominigame()
    {
        characterController.enabled = false; 
        player.transform.position = posicaoantesminigame; 
        characterController.enabled = true; 
    }

    public bool CanPlayMinigame()
    {
        return minigamesJogadosHoje < maxMinigamesPorDia;
    }
    public void RegisterMinigamePlayed()
    {
        minigamesJogadosHoje++;
    }
}
