using System.Collections.Generic;
using System.Linq;
using TMPro;

using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject trunfoPrefab;
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private GameObject carta1;
    [SerializeField] private GameObject carta2;
    [SerializeField] private GameObject carta3;
    [SerializeField] private GameObject trunfosinv;
    [SerializeField] private GameObject pTrunfo1;
    [SerializeField] private GameObject pTrunfo2;
    [SerializeField] private TextMeshProUGUI soma1;
    [SerializeField] private TextMeshProUGUI soma2;
    private Jogador player1;
    private Jogador player2;
    private Baralho baralho;
    private int turn;
    private int contaPasse;
    private int metaJogo;

    void Start()
    {

        baralho = new Baralho();
        player1 = new Jogador(baralho);
        player2 = new Jogador(baralho);
        carta3.gameObject.SetActive(false);
        turn = 0;
        contaPasse = 0;
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        desenhaTela(player1);

        inventoryPanel.SetActive(false);
        metaJogo = 21;

        Debug.Log("Tamanho das cartas jogador1 " + player1.getMaoJogador().Count);
        Debug.Log("Tamanho das cartas jogador2 " + player2.getMaoJogador().Count);
        offTrunfoinv(trunfosinv);
        pTrunfo1.gameObject.SetActive(false);
        pTrunfo2.gameObject.SetActive(false);

    }

    void Update()
    {
        player1.calculaMao();
        player2.calculaMao();

        if (contaPasse != 2)
        {
            Jogador atual = (turn == 0 ? player1 : player2);

            if (atual.abrirInventario())
            {
                ToggleInventory(atual);
                onTrunfoinv(trunfosinv);
            }

            if (atual.comprarCarta(baralho))
            {
                contaPasse = 0;
            }

            if (atual.passarVez())
            {
                if (inventoryPanel.activeSelf)
                {
                    ToggleInventory(atual);
                    offTrunfoinv(trunfosinv);
                }
                passarVez(atual);
                contaPasse += 1;

            }
            desenhaTela(atual);
        }
        else
        {
            int somaPlayer1 = metaJogo - player1.getSoma();
            int somaPlayer2 = metaJogo - player2.getSoma();

            if (somaPlayer1 >= 0 && somaPlayer2 >= 0)
            {
                if (somaPlayer1 < somaPlayer2)
                {
                    txt.text = "Vencedor foi o jogador 1";
                }
                else if (somaPlayer1 > somaPlayer2)
                {
                    txt.text = "Vencedor foi o jogador 2";
                }
                else
                {
                    txt.text = "Empate";
                }
            }
            else if (somaPlayer1 < 0 && somaPlayer2 >= 0)
            {
                txt.text = "Vencedor foi o jogador 2";
            }
            else if (somaPlayer2 < 0 && somaPlayer1 >= 0)
            {
                txt.text = "Vencedor foi o jogador 1";
            }
            else
            {
                if (somaPlayer1 > somaPlayer2)
                {
                    txt.text = "Vencedor foi o jogador 1";
                }
                else if (somaPlayer1 < somaPlayer2)
                {
                    txt.text = "Vencedor foi o jogador 2";
                }
                else
                {
                    txt.text = "Empate";
                }
            }
        }

        if (!inventoryPanel.activeSelf)
            offTrunfoinv(trunfosinv);

    }

    public void ToggleInventory(Jogador atual)
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);



        if (!isActive)
        {
            AtualizarInventario(atual);

        }
    }


    public void AtualizarInventario(Jogador atual)
    {
        LimparInventario();

        foreach (var trunfo in atual.getInventarioJogador())
        {
            if (trunfoPrefab != null && inventoryPanel != null)
            {
                GameObject trunfoObj = Instantiate(trunfoPrefab, inventoryPanel.transform);

                TextMeshProUGUI trunfoText = trunfoObj.GetComponentInChildren<TextMeshProUGUI>();
                if (trunfoText != null)
                {
                    trunfoText.text = trunfo.GetType().Name;
                }
            }
        }
    }



    void LimparInventario()
    {
        if (inventoryPanel != null)
        {
            foreach (Transform child in inventoryPanel.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }


    void passarVez(Jogador atual)
    {
        turn = (turn == 0) ? 1 : 0;
        txt.text = "Seu Turno ";
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        atual = (turn == 0 ? player1 : player2);
    }



    void desenhaTela(Jogador atual)
    {
        atual.calculaMao();



        if (!player1.iscarta3())
            soma1.text = (player1.getMaoJogador()[1] + player1.getMaoJogador()[0] + "/21");
        else
            soma1.text = (player1.getMaoJogador()[1] + player1.getMaoJogador()[0] + player1.getMaoJogador()[2] + "/21");


        if (!player2.iscarta3())
            soma2.text = (player2.getMaoJogador()[1] + player2.getMaoJogador()[0] + "/21");
        else
            soma2.text = (player2.getMaoJogador()[1] + player2.getMaoJogador()[0] + player2.getMaoJogador()[2] + "/21");

        if (!atual.iscarta3())
        {



            CartaController c1 = carta1.GetComponent<CartaController>();
            c1.setSprite(atual.getMaoJogador()[0] - 1);

            CartaController c2 = carta2.GetComponent<CartaController>();
            c2.setSprite(atual.getMaoJogador()[1] - 1);
            carta3.gameObject.SetActive(false);
        }
        else
        {



            carta3.gameObject.SetActive(true);
            CartaController c1 = carta1.GetComponent<CartaController>();
            c1.setSprite(atual.getMaoJogador()[0] - 1);

            CartaController c2 = carta2.GetComponent<CartaController>();
            c2.setSprite(atual.getMaoJogador()[1] - 1);

            CartaController c3 = carta3.GetComponent<CartaController>();
            c3.setSprite(atual.getMaoJogador()[2] - 1);


        }


        // Debug.Log(atual.getMaoJogador().Count + " e local " + atual.getMaoJogador().Count);
        //if (atual.getMaoJogador().Count > 2)
        //Debug.Log("Soma das cartas eh " + (atual.getMaoJogador()[1] + atual.getMaoJogador()[0] + atual.getMaoJogador()[2]));
        // Debug.Log(atual.getSoma());
        // if (atual.getMaoJogador().Count > 2)
        //Debug.Log("3 carta eh " + atual.getMaoJogador()[2]);


    }


    private void offTrunfoinv(GameObject obj)
    {
        foreach (Transform filho in obj.transform)
        {
            filho.gameObject.SetActive(false);
        }
    }

    private void onTrunfoinv(GameObject obj)
    {
        foreach (Transform filho in obj.transform)
        {
            filho.gameObject.SetActive(true);
        }
    }
}