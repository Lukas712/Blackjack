using System.Collections.Generic;
using UnityEngine;

public class Baralho
{
    private List<int> cartas;

    Baralho()
    {
        cartas = new List<int>();
        for(int i = 1; i<=11; i+=1)
        {
            cartas.Add(i);
        }
    }
    public List<int> getCarta(){return cartas;}
    public void insereCarta(int carta){return;}

    public int removeCarta(int carta){
        cartas.Remove(carta);
        return carta;
        }
    private void embaralhaCartas(){return;}
}