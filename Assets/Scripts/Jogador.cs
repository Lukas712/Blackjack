using System.Collections.Generic;
using UnityEngine;

public abstract class Jogador
{
    private int[] maoJogador;
    private List<Trunfo> inventario;
    private int pontosDeVida;
    private int betAtual;

    Jogador(){
        inventario = new List<Trunfo>();
        maoJogador = new int[11];
        pontosDeVida = 10;
        betAtual = 0;
    }
    public int getBet(){return betAtual;}
    public void setBet(int val){betAtual = val;}

    public int getVida(){return pontosDeVida;}
    public void setVida(int val){pontosDeVida = val;}

    public int[] getMaoJogador(){return maoJogador;}
    public List<Trunfo> getInventarioJogador(){return inventario;}

    public void insereInventario(Trunfo trunfo){inventario.Add(trunfo);}

    public void insereCarta(){}

    public abstract void passarVez();
    public abstract void comprarCarta();

    public abstract void abrirInventario();

    public abstract void usaTrunfo(Trunfo trunfo, Jogador Adversario);

    private int calculaVida(){return 0;}

    private int calculaMao(){return 0;}

}
