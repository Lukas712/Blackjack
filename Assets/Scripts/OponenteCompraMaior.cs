using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class OponenteCompraMaior : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        adversario.insereCarta(compraMaior(baralho));
    }

    public override string descricaoTrunfo(){
        return "Compra a maior carta do baralho possível para o adversário";
    }

    private int compraMaior(Baralho baralho)
    {
        List<int> maior = baralho.getCarta();
        maior.Sort();
        return maior.Last();

    }
}