using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject trunfoPrefab;
    [SerializeField] private TextMeshProUGUI txt;

    private Jogador player1;
    private Jogador player2;
    private Baralho baralho;
    private int turn;
    private int contaPasse;

    void Start()
    {
        baralho = new Baralho(); 
        player1 = new Jogador(baralho);
        player2 = new Jogador(baralho);
        turn = 0;
        contaPasse = 0;
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        if(contaPasse != 2)
        {
            Jogador atual = (turn == 0 ? player1 : player2);

            if (atual.abrirInventario())
            {
                ToggleInventory(atual);
                Debug.Log("Mao do jogador: " + (turn == 0 ? "Jogador 1" : "Jogador 2"));
                for(int i = 0; i<atual.getMaoJogador().Count; i+=1)
                {
                    Debug.Log(atual.getMaoJogador()[i]);
                }
            }
            if (atual.comprarCarta(baralho))
            {
                contaPasse = 0;
                atual.calculaMao();
            }
            if (atual.passarVez())
            {
                
                if(inventoryPanel.activeSelf)
                {
                    ToggleInventory(atual);
                }
                passarVez(atual);
                contaPasse+=1;
            }
        }
        else
        {
            if(21-player1.getSoma() > 0)
            {
                if(21-player2.getSoma() > 0)
                {
                    if(player1.getSoma() < player2.getSoma())
                    {
                        txt.text = "Vencedor foi o jogador 1";
                    }
                    else
                    {
                        txt.text = "Vencedor foi o jogador 2";
                    }
                }
                else
                {
                    txt.text = "Vencedor foi o jogador 1";
                }
            }
            else if( 21-player1.getSoma() < 0)
            {
                if(21-player2.getSoma() < 0)
                {
                    if(21-player1.getSoma() > 21-player2.getSoma())
                    {
                        txt.text = "Vencedor foi o jogador 1";
                    }
                    else
                    {
                        txt.text = "Vencedor foi o jogador 2";
                    }
                }
                else
                {
                    txt.text = "Vencedor foi o jogador 2";
                }
            }
            else
            {
                txt.text = "Empate";
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
}