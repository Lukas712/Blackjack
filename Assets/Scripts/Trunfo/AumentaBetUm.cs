using UnityEngine;

public class AumentaBetUm : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        adversario.setBet(adversario.getBet()+1);
    }

    public override string descricaoTrunfo(){
        return "Aumenta a aposta do adversário em 1";
    }
}