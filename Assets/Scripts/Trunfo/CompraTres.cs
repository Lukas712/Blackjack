using UnityEngine;

public class CompraTres : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.getCarta(3));
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 3";
    }
}