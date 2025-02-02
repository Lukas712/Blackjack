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

    void Start()
    {
        baralho = new Baralho(); 
        player1 = new Jogador();
        player2 = new Jogador();
        for (int i = 0; i < 4; i++)
        {
            player1.comprarCarta(baralho);
            player2.comprarCarta(baralho);
        }
        turn = 0;
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        Jogador atual = (turn == 0 ? player1 : player2);
        if (atual.abrirInventario())
        {
            ToggleInventory(atual);
        }
        if (atual.comprarCarta(baralho))
        {
            Debug.Log("Carta Comprada");
        }
        if (atual.passarVez())
        {
            Debug.Log("Vez Passada");
            passarVez(atual);
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