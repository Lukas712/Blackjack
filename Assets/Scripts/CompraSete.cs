using UnityEngine;

public class CompraSete : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(baralho.getCarta(7))
    }

    public override string descricaoTrunfo(){
        return "Compra (se estiver no baralho) a carta de número 7";
    }
}