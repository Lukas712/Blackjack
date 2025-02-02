using UnityEngine;




public class Carta : MonoBehaviour
{
    public string naipe { get; private set; }
    public string valor { get; private set; }


    [SerializeField] private string nome;

    public Carta(string valor)
    {

        this.valor = valor;
    }

    public int GetValorNumerico(bool usarValorAltoParaAs = false)
    {
        switch (this.valor)
        {
            case "A":
                return usarValorAltoParaAs ? 11 : 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "10":
            case "J":
            case "Q":
            case "K":
                return 10;
            default:
                Debug.LogError("Valor inválido da carta.");
                return 0;
        }
    }

    public override string ToString()
    {
        return $"{this.valor}";
    }
}

