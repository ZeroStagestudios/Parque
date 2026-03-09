using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int municao = 30;
    public Transform jogador;
    public Transform armaTransform;
    public float distanciaMaxima = 5f;
    public GameObject waterTrailPrefab;
    public float alturaParabola = 2f;
    public float duracaoTiro = 0.3f;

    public AudioClip somTiro;

    MinigameManager minigameManager;
    LayerMask duckLayer;

    void Start()
    {
        minigameManager = FindFirstObjectByType<MinigameManager>();
        duckLayer = LayerMask.GetMask("Duck");
    }
    void Update()
    {
        AtualizarPosicaoArma();

        if (Input.GetMouseButtonDown(0) && municao > 0){
            Atirar();
            AudioManager.instance.PlaySFX(somTiro);
        }
    }
    void AtualizarPosicaoArma()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 offset = Vector3.ClampMagnitude(worldPos - jogador.position, distanciaMaxima);
        armaTransform.position = jogador.position + offset;
        armaTransform.LookAt(worldPos);
    }
    void Atirar()
    {
        municao--;
        minigameManager.AtualizarMunicao(municao);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, duckLayer))
        {
            StartCoroutine(MoverTrail(armaTransform.position, hit.point));

            if (hit.collider.CompareTag("Duck"))
            {
                Duck duck = hit.collider.gameObject.GetComponent<Duck>();
                if (duck != null && duck.AcertarPato())
                    minigameManager.Patoacertado();
            }
        }
        else
        {
            Vector3 pontoDistante = ray.origin + ray.direction * 20f;
            StartCoroutine(MoverTrail(armaTransform.position, pontoDistante));
        }
    }

    IEnumerator MoverTrail(Vector3 origem, Vector3 destino)
    {
        GameObject trail = Instantiate(waterTrailPrefab, origem, Quaternion.identity);
        float tempo = 0f;
        Vector3 pontoMedio = (origem + destino) / 2f + Vector3.up * alturaParabola;

        while (tempo < 1f)
        {
            tempo += Time.deltaTime / duracaoTiro;
            Vector3 a = Vector3.Lerp(origem, pontoMedio, tempo);
            Vector3 b = Vector3.Lerp(pontoMedio, destino, tempo);
            trail.transform.position = Vector3.Lerp(a, b, tempo);
            yield return null;
        }
        Destroy(trail, 0.5f);
    }
}