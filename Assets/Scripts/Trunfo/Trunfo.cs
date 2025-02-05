using UnityEngine;

public abstract class Trunfo{
    
    public Trunfo(){}
    public abstract void efeitoTrunfo(Baralho baralho,Jogador usuario, Jogador adversario);
    public abstract string descricaoTrunfo();

}