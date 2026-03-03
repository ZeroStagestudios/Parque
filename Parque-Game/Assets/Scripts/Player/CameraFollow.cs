using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform player;
   public Vector3 offset = new Vector3 (0f, 10f, -7f);
   public float suavidade = 5f;

    void LateUpdate()
    {
        Vector3 posicaoAlvo = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicaoAlvo, suavidade * Time.deltaTime);
    
        transform.rotation = Quaternion.Euler(45f,0f,0f);
    }
    
}
