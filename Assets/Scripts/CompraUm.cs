using UnityEngine;

public class CompraUm : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.removeCarta(1));
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 1";
    }
}