using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDManager : MonoBehaviour
{
    public TMP_Text txtPatos;
    public TMP_Text txtMunicao;
    public TMP_Text txtTempo;
    public void AtualizarPatos(int patos)
    {
        txtPatos.text = "Patos Acertados: " + patos.ToString();
    }
    public void AtualizarMunicao(int municao)
    {
        txtMunicao.text = "Munição: " + municao.ToString();
    }
    public void AtualizarTempo(int tempo)

    {
        txtTempo.text = "Tempo Restante: " + tempo.ToString() + "s";
    }
}
