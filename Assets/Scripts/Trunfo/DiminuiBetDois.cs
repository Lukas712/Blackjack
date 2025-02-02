using UnityEngine;

public class DiminuiBetDois : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        if(usuario.getBet()-2 < 0)
        {
            usuario.setBet(0);
            return;
        }
        usuario.setBet(usuario.getBet()-2);
    }

    public override string descricaoTrunfo(){
        return "Diminui sua aposta em 1";
    }
}