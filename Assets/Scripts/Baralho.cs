using System.Collections.Generic;
using UnityEngine;

public class Baralho
{
    private List<Cartas> cartas;

    public Baralho()
    {
        cartas = new List<Cartas>();
        string[] naipes = { "Copas", "Espadas", "Ouros", "Paus" };
        string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        foreach (string naipe in naipes)
        {
            foreach (string valor in valores)
            {
                cartas.Add(new Cartas(naipe, valor));
            }
        }

        EmbaralhaCartas();
    }

    public void EmbaralhaCartas()
    {
        cartas = cartas.OrderBy(c => Random.Range(0, cartas.Count)).ToList();
    }

    public Cartas CompraCarta()
    {
        if (cartas.Count == 0) return null;

        Cartas carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }
}
