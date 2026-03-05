using System.Collections;
using UnityEngine;

public class Duck : MonoBehaviour
{
  public DuckManager duckManager;
  Animator animator;

    void Awake()
    {
        duckManager = FindFirstObjectByType<DuckManager>();
        animator = GetComponentInChildren<Animator>();
    }
    public void AtivarDuck()
    {
        gameObject.SetActive(true);
        IEnumerator coroutine = AtivarduckAleatorio();
        StartCoroutine(coroutine);
      
    }    
    IEnumerator AtivarduckAleatorio()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        DesativarDuck();
    }
    public void DesativarDuck()
    {
        
        gameObject.SetActive(false);
        duckManager.LiberarDuck(this); 

    }
    
}
