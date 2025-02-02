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

    void Start()
    {
        xmeia = posinit.position.x / 2;
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
        desenhaTela(player1, posinit.transform, posTrunfo);
        desenhaTela(player2, posinitp2.transform, posTrunfo2);

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



    void desenhaTela(Jogador player, Transform pRef, Transform pTrunfo)
    {
        Debug.Log("Entrou " + player.getMaoJogador().Count + 1);
        for (int i = 0; i < player.getMaoJogador().Count + 1; i++)
        {
            GameObject carta = Instantiate(Cartas, pRef.position + new Vector3(i * 0.1f + xmeia + xmeia, -0.95f, 0), Quaternion.identity);
            CartaController cscript = carta.GetComponent<CartaController>();
            cscript.setSprite(1);
        }






    }
}