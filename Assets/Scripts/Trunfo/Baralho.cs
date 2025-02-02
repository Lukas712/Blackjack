using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Baralho
{
    private List<Carta> cartas;

    public Baralho()
    {
        cartas = new List<Carta>();
        string[] valores = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        EmbaralhaCartas();
    }

    public void EmbaralhaCartas()
    {
        cartas = cartas.OrderBy(c => Random.Range(0, cartas.Count)).ToList();
    }

    public Carta CompraCarta()
    {
        if (cartas.Count == 0) return null;

        Carta carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }
}
