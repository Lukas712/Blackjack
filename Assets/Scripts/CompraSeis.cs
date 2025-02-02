using UnityEngine;

public class CompraSeis : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.removeCarta(6));
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 6";
    }
}