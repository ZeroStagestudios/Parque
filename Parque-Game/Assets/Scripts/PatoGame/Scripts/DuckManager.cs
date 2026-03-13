using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
     List<Duck> ducks = new List<Duck>();
    public int patosSimultaneos = 3;
    void Awake()
    {
        ducks.AddRange(FindObjectsOfType<Duck>(true));
        foreach (Duck duck in ducks)
        duck.duckManager = this;
    }
    void Start()
    {
        IniciarRodada();
    }
    public void IniciarRodada()
    {
        List<Duck> patosDisponiveis = new List<Duck>(ducks);
        for (int i = 0; i < patosSimultaneos; i++)
        {
            int index = Random.Range(0, patosDisponiveis.Count);
            patosDisponiveis[index].AtivarDuck();
            patosDisponiveis.RemoveAt(index);
        }
    }
    public void LiberarDuck(Duck patodesativado)
    {
        List<Duck> patosInativos = ducks.FindAll(duck => !duck.gameObject.activeSelf && duck != patodesativado);
        if (patosInativos.Count > 0)
        {
            int index = Random.Range(0, patosInativos.Count);
            patosInativos[index].AtivarDuck();
        }        
        
    }
}
