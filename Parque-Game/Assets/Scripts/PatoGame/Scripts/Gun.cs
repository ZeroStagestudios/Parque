using UnityEngine;

public class Gun : MonoBehaviour
{
    public int municao = 30;

    MinigameManager minigameManager;
    public Transform jogador;
    public Transform armaTransform;
    public float distanciaMaxima = 5f;

    void Start()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
    }

    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 offset = worldPos - jogador.position;
        offset = Vector3.ClampMagnitude(offset, distanciaMaxima);
        armaTransform.position = jogador.position + offset;
        armaTransform.LookAt(worldPos);


        if (Input.GetMouseButtonDown(0) && municao > 0)
        {
            municao--;
            Debug.Log("Tiro disparado! Munição restante: " + municao);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            LayerMask duckLayer = LayerMask.GetMask("Duck");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, duckLayer))
            {
                Debug.Log("Acertou: " + hit.collider.gameObject.name + " | Tag: " + hit.collider.tag);

                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
                if (hit.collider.CompareTag("Duck"))
                {
                    Debug.Log("Pato Acertado!");
                 Duck duck = hit.collider.gameObject.GetComponent<Duck>();
                 if (duck != null)
                 {
                    duck.DesativarDuck();
                    minigameManager.Patoacertado();
                 }
                }
            }
            minigameManager.AtualizarMunicao(municao);
        }
    }

}
