using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TrocaCarta : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        int cartaAdversario = adversario.getMaoJogador().Last();
        int cartaUsuario = usuario.getMaoJogador().Last();
        adversario.removeCarta(cartaAdversario);
        adversario.insereCarta(cartaUsuario);
        usuario.removeCarta(cartaUsuario);
        usuario.insereCarta(cartaAdversario);

    }

    public override string descricaoTrunfo(){
        return "Troca sua última carta com a do adversário";
    }
}