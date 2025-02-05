using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Baralho
{
    private List<int> cartas;

    // Start is called before the first frame update
    public Baralho()
    {
        cartas = new List<int>();
        for (int i = 1; i <= 11; i += 1)
        {
            cartas.Add(i);
        }
        EmbaralhaCartas();
    }

    public void EmbaralhaCartas()
    {
        System.Random rng = new System.Random();
        cartas = cartas.OrderBy(c => rng.Next()).ToList();
        //cartas = cartas.OrderBy(c => Random.Range(0, cartas.Count)).ToList();
    }

    public int CompraCarta()
    {
        if (cartas.Count == 0)
        {
            return -1;
        }
        int compra = cartas.First();
        cartas.RemoveAt(0);
        return compra;
    }

    public int getCarta(int val)
    {
        if(cartas.Remove(val))
        {
            return val;
        }
        return -1;
    }
}
