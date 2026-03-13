using System;
using System.Collections;
using UnityEngine;

public class ConfirmacaoUI : MonoBehaviour
{
    public GameObject uiPanel;
    public static ConfirmacaoUI Instance;
    IEnumerator passarDiaCoroutine()
    {
        uiPanel.SetActive(false);
        yield return FadeController.Instance.StartFadeOut(1f);
        GameManager.Instance.NextDay();
        yield return FadeController.Instance.StartFadeIn(1f);
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void BtnSim()
    {
        StartCoroutine(passarDiaCoroutine());
    }
    public void BtnNao()
    {
        uiPanel.SetActive(false);
    }
}
