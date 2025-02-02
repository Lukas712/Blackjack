using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CompraPerfeitaUm : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        usuario.insereCarta(compraMelhor(baralho, usuario));
    }

    public override string descricaoTrunfo(){
        return "Compra a melhor carta do baralho possível para sua mão";
    }

    private int compraMelhor(Baralho baralho, Jogador usuario)
    {
        List<int> mao = usuario.getMaoJogador();
        int soma = 0;
        foreach(int carta in mao)
        {
            soma+=carta;
        }
        if(soma>jogo.getPonto())
        {
            return 0;
        }
        else if(soma< jogo.getPonto())
        {
            List<int> melhor = baralho.getCarta();
            int somaCarta = soma+melhor.First();
            int cartaMelhor = melhor.First();
            foreach(int carta in melhor)
            {
            
                if((somaCarta < soma+carta) && (somaCarta <= jogo.getPonto()) && (soma+carta <= jogo.getPonto()))
                {
                    somaCarta = soma+carta;
                    cartaMelhor = carta;
                }
            }
            return cartaMelhor;
        }
        else
        {
            return 0;
        }

    }
}