using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DevolveBaralhoOponente : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        baralho.insereCarta(adversario.getMaoJogador().Last());
        adversario.removeCarta(adversario.getMaoJogador().Last());
    }

    public override string descricaoTrunfo(){
        return "Devolve a ultima carta da mão do oponente para o baralho";
    }
}