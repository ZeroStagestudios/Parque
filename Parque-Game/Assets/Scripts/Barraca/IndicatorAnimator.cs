using UnityEngine;

public class IndicatorAnimator : MonoBehaviour
{
    float y;
    public float minScale;
    public float amplitude = 0.5f;
    public Vector3 indicador;

    public static object Instance { get; internal set; }

    void Awake()
    {
      indicador = transform.localPosition;
    }
    void Update()
    {
     y = (float)(Mathf.Sin(Time.time * 0.5f) * amplitude);
     transform.localPosition = new Vector3(indicador.x, y + indicador.y, indicador.z);
     transform.localScale = Vector3.one * (minScale + Mathf.PingPong(Time.time * 0.7f, 1f));
    }
}
