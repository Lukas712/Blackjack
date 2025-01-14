using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using NUnit.Framework;

public class AumentaBetDoisPlus : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
        adversario.setBet(adversario.getBet()+2);

        Type tipoBase = typeof(Trunfo);
        var classesDerivadas = Assembly.GetAssembly(tipoBase).GetTypes().Where(type => type.IsSubclassOf(tipoBase) && !type.IsAbstract).ToList();

        if(classesDerivadas.Any())
        {
            System.Random random = new System.Random();
            Type tipoTrunfo = classesDerivadas[random.Next(classesDerivadas.Count())];

            Trunfo instanciaTrunfo = (Trunfo)Activator.CreateInstance(tipoTrunfo);
            usuario.insereInventario(instanciaTrunfo);
        }
    }

    public override string descricaoTrunfo(){
        return "Aumenta a aposta do adversário em 2 e compra um trunfo";
    }
}