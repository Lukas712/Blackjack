using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI txt;
    private Jogador player1;
    private Jogador player2;
    private bool passou;

    int turn;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player1 = new Jogador();
        player2 = new Jogador();
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");

    }

    // Update is called once per frame
    void Update()
    {


    }


    void passarVez()
    {
        if (turn == 0)
            turn++;
        else
            turn = 0;

        txt.text = "Seu Turno";
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
    }



}
