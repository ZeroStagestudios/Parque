using UnityEngine;

public class IndicatorShake : MonoBehaviour
{
  public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private System.Collections.IEnumerator ShakeCoroutine()
    {
        float shakeDuration = 0.5f; // Duração do shake
        float shakeMagnitude = 0.1f; // Magnitude do shake
        Vector3 originalPosition = transform.localPosition; // Posição original do indicador

        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition; // Retorna à posição original
    }
}
