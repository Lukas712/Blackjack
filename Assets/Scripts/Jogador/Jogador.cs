using System.Collections.Generic;
using UnityEngine;

public class Jogador
{
    private List<int> maoJogador;
    private List<Trunfo> inventario;
    private int pontosDeVida;
    private int betAtual;
    private int soma;
    private bool carta3;

    public Jogador(Baralho baralho)
    {
        inventario = new List<Trunfo>();
        maoJogador = new List<int>();

        pontosDeVida = 10;
        betAtual = 1;
        soma = 0;
        insereCarta(baralho.CompraCarta());
        insereCarta(baralho.CompraCarta());

    }
    public int getBet() { return betAtual; }
    public void setBet(int val)
    {
        if (val < 0)
        {
            val = 0;
        }
        betAtual = val;
    }

    public int getVida() { return pontosDeVida; }
    public void setVida(int val) { pontosDeVida = val; }

    public List<int> getMaoJogador() { return maoJogador; }

    public void insereCarta(int val)
    {
        if (val == -1)
        {
            return;
        }
        maoJogador.Add(val);

    }

    public void removeCarta(int val)
    {
        maoJogador.Remove(val);
    }
    public bool passarVez()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            return true;
        }
        return false;
    }
    public bool comprarCarta(Baralho baralho)
    {
        if (maoJogador.Count < 6 && Input.GetKeyDown(KeyCode.F))
        {
            insereCarta(baralho.CompraCarta());
            return true;
        }
        return false;
    }

    public bool abrirInventario()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            return true;
        }
        return false;

    }

    public void usaTrunfo(Trunfo trunfo, Jogador Adversario, Baralho baralho)
    {
        trunfo.efeitoTrunfo(baralho, this ,Adversario);
    }

    public int calculaVida()
    {
        return ((pontosDeVida -= betAtual) >= 0 ? pontosDeVida : 0);
    }

    public void calculaMao()
    {
        soma = 0;
        for (int i = 0; i < maoJogador.Count; i += 1)
        {
            soma += maoJogador[i];
        }
    }

    public int getSoma() { return soma; }

    public void reseta(Baralho baralho)
    {
        maoJogador.Clear();
        insereCarta(baralho.CompraCarta());
        insereCarta(baralho.CompraCarta());
    }

}
