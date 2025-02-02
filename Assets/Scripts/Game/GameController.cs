using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject trunfoPrefab;
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private Transform posinit;
    [SerializeField] private Transform posinitp2;
    [SerializeField] private Transform posTrunfo;
    [SerializeField] private Transform posTrunfo2;

    [SerializeField] private GameObject Cartas;
    private GameObject[] CartasPrefab;
    private float xmeia;

    private Jogador player1;
    private Jogador player2;
    private Baralho baralho;
    private int turn;
    private int contaPasse;
    private int metaJogo;

    void Start()
    {
        xmeia = posinit.position.x / 2;
        baralho = new Baralho();
        player1 = new Jogador(baralho);
        player2 = new Jogador(baralho);
        turn = 0;
        contaPasse = 0;
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        desenhaTela(player1, posinit.transform, posTrunfo);
        desenhaTela(player2, posinitp2.transform, posTrunfo2);

        inventoryPanel.SetActive(false);
        metaJogo = 21;
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
                }
                passarVez(atual);
                contaPasse += 1;
            }
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



    void desenhaTela(Jogador player, Transform pRef, Transform pTrunfo)
    {
        Debug.Log("Entrou " + player.getMaoJogador().Count + 1);
        for (int i = 0; i < player.getMaoJogador().Count + 1; i++)
        {
            GameObject carta = Instantiate(Cartas, pRef.position + new Vector3(i * 0.1f + xmeia + xmeia, -0.95f, 0), Quaternion.identity);
            CartaController cscript = carta.GetComponent<CartaController>();
            cscript.setSprite(i);
        }






    }
}