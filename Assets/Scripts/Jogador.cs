using UnityEngine;

public abstract class Jogador
{
    private int[] maoJogador;
    private int[] inventario;
    private int pontosDeVida;
    private int betAtual;

    public abstract void passarVez();
    public abstract void comprarCarta();

    public abstract void abrirInventario();

    public abstract void usaTrunfo(Trunfo trunfo, Jogador Adversario);

    private int calculaVida(){return 0;}

    private int calculaMao(){return 0;}

}
