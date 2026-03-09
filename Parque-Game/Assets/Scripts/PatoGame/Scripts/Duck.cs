using System.Collections;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public DuckManager duckManager;
    public Animator animator;
    public float duracaoAnimacao = 1.33f;
    public float tempoVisivel = 3f;
    
    bool foiAcertado = false;
    Coroutine coroutineAtiva;

    public void AtivarDuck()
    {
        if (gameObject.activeSelf) return;
        foiAcertado = false;
        gameObject.SetActive(true);
        coroutineAtiva = StartCoroutine(CicloDoPato());
    }

    IEnumerator CicloDoPato()
    {
        yield return new WaitForSeconds(duracaoAnimacao);
        yield return new WaitForSeconds(tempoVisivel);
        if (foiAcertado) yield break;
        animator.SetTrigger("GoDown");
        yield return new WaitForSeconds(duracaoAnimacao);
        if (foiAcertado) yield break;
        DesativarDuck();
    }

    IEnumerator DesativarAposAnimacao()
    {
        yield return new WaitForSeconds(duracaoAnimacao);
        DesativarDuck();
    }

    public bool AcertarPato()
    {
        if (foiAcertado) return false;
        foiAcertado = true;
        if (coroutineAtiva != null) StopCoroutine(coroutineAtiva);
        animator.SetTrigger("Hit");
        StartCoroutine(DesativarAposAnimacao());
        return true;
    }

    public void DesativarDuck()
    {
        if (!gameObject.activeSelf) return;
        gameObject.SetActive(false);
        duckManager.LiberarDuck(this);
    }
}