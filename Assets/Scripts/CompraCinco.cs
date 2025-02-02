using UnityEngine;

public class CompraCinco : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.removeCarta(5));
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 5";
    }
}