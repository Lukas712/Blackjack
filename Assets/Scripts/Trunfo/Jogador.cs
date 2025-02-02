using System.Collections.Generic;
using UnityEngine;

public class Jogador
{
    private List<Carta> maoJogador;
    private List<Trunfo> inventario;
    private int pontosDeVida;
    private int betAtual;
    private int soma;

    public Jogador()
    {
        inventario = new List<Trunfo>();
        maoJogador = new List<Carta>();
        pontosDeVida = 10;
        betAtual = 0;

    }
    public int getBet() { return betAtual; }
    public void setBet(int val) { betAtual = val; }

    public int getVida() { return pontosDeVida; }
    public void setVida(int val) { pontosDeVida = val; }

    public List<Carta> getMaoJogador() { return maoJogador; }
    public List<Trunfo> getInventarioJogador() { return inventario; }

    public void insereInventario(Trunfo trunfo) { inventario.Add(trunfo); }

    public void insereCarta(int val) { }

    public void removeCarta(int val) { }
    public void passarVez()
    {

    }
    public void comprarCarta()
    {

    }

    public void abrirInventario()
    {

    }

    public void usaTrunfo(Trunfo trunfo, Jogador Adversario)
    {

    }

    private int calculaVida() { return 0; }

    private int calculaMao() { return 0; }

    public int getSoma() { return this.soma; }

}
