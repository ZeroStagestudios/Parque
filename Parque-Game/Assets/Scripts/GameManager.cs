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
    private CharacterController characterController;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject); 
        Debug.Log("Posição salva: " + GameManager.Instance.posicaoantesminigame);
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
    }

    public void Posicaominigame()
    {
        characterController.enabled = false; 
        player.transform.position = posicaoantesminigame; 
        characterController.enabled = true; 
    }
}
