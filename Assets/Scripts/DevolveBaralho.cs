using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DevolveBaralho : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        baralho.insereCarta(usuario.getMaoJogador().Last());
        usuario.removeCarta(usuario.getMaoJogador().Last());
    }

    public override string descricaoTrunfo(){
        return "Devolve a ultima carta da mão do oponente para o baralho";
    }
}