using System;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class CompraUmTrunfo : Trunfo
{
    public override void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario){
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
        return "Compra um trunfo";
    }
}