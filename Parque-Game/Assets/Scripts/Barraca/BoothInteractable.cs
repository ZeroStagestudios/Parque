using System;
using UnityEngine;

public class BoothInteractable : MonoBehaviour
{
    public bool isMinigame = true;
    public string boothName;
    public GameObject indicador;
    void Awake()
    {
        Debug.Log("indicador: " + indicador);
    }
    void Start()
    {
        indicador.SetActive(false);
    }
    
    public void ShowIndicator()
    {
        if (isMinigame)
        {
            indicador.SetActive(true);
        }
    }

    public void HideIndicator()
    {
        if (isMinigame)
        {
            indicador.SetActive(false);
        }
    }

    public bool HasPlayedToday(){
        return PlayerPrefs.GetInt(boothName, 0) == GameManager.Instance.dia;;
    }
    public void RegisterPlay(){
        PlayerPrefs.SetInt(boothName, GameManager.Instance.dia);
    }

   
}
