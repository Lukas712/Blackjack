using UnityEngine;

public class AumentaBetDois : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        adversario.setBet(adversario.getBet()+2);
    }

    public override string descricaoTrunfo(){
        return "Aumenta a aposta do adversário em 2";
    }
}