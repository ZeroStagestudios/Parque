using System.Collections;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    private CanvasGroup fade;
    public static FadeController Instance;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);

        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        fade = GetComponentInChildren<CanvasGroup>();
        Debug.Log("CanvasGroup encontrado: " + fade);

    }
    IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Debug.Log("FadeOut iniciado, fade: " + fade);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            fade.alpha = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        fade.alpha = 1f; 
    }
     IEnumerator FadeIn(float duration)

    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            fade.alpha = 1f - Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        fade.alpha = 0f; 
    }
    public Coroutine StartFadeOut(float duration)
    {
        return StartCoroutine(FadeOut(duration));
    }
    public Coroutine StartFadeIn(float duration)
    {
        return StartCoroutine(FadeIn(duration));
    }
}
