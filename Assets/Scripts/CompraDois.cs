using UnityEngine;

public class CompraDois : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.getCarta(2))
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 2";
    }
}