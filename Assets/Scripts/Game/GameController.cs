
using System.Collections;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject trunfoPrefab;
    [SerializeField] private GameObject descricaoTrunfo;
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private GameObject carta1;
    [SerializeField] private GameObject carta2;
    [SerializeField] private GameObject carta3;
    [SerializeField] private GameObject carta4;
    [SerializeField] private GameObject carta5;
    [SerializeField] private GameObject carta6;
    [SerializeField] private string cena;

    [SerializeField] private GameObject cartaVirada1;
    [SerializeField] private GameObject cartaVirada2;
    [SerializeField] private GameObject cartaVirada3;
    [SerializeField] private GameObject cartaVirada4;
    [SerializeField] private GameObject cartaVirada5;
    [SerializeField] private GameObject cartaVirada6;
    [SerializeField] private GameObject trunfosinv;
    [SerializeField] private GameObject pTrunfo1;
    [SerializeField] private GameObject pTrunfo2;
    [SerializeField] private GameObject pTrunfo3;
    [SerializeField] private GameObject pTrunfo4;

    [SerializeField] private TextMeshProUGUI soma1;
    [SerializeField] private TextMeshProUGUI soma2;

    [SerializeField] private TextMeshProUGUI betUsuario;
    [SerializeField] private TextMeshProUGUI betAdversario;

    [SerializeField] private TextMeshProUGUI vidaUsuario;

    [SerializeField] private TextMeshProUGUI vidaAdversario;

    private Jogador player1;
    private Jogador player2;
    private Baralho baralho;
    private int turn;
    private int contaPasse;
    private int metaJogo;
    private bool acaoBloqueada;

    void Start()
    {

        baralho = new Baralho();
        player1 = new Jogador(baralho);
        player2 = new Jogador(baralho);
        acaoBloqueada = false;
        turn = 0;
        contaPasse = 0;
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        desenhaTela(player1);

        inventoryPanel.SetActive(false);
        metaJogo = 21;

        Debug.Log("Tamanho das cartas jogador1 " + player1.getMaoJogador().Count);
        Debug.Log("Tamanho das cartas jogador2 " + player2.getMaoJogador().Count);
        // offTrunfoinv(trunfosinv);
        pTrunfo1.gameObject.SetActive(false);
        pTrunfo2.gameObject.SetActive(false);
        pTrunfo3.gameObject.SetActive(false);
        pTrunfo4.gameObject.SetActive(false);

        carta3.gameObject.SetActive(false);
        carta4.gameObject.SetActive(false);
        carta5.gameObject.SetActive(false);
        carta6.gameObject.SetActive(false);

        cartaVirada3.gameObject.SetActive(false);
        cartaVirada4.gameObject.SetActive(false);
        cartaVirada5.gameObject.SetActive(false);
        cartaVirada6.gameObject.SetActive(false);
    }

    void Update()
    {
        player1.calculaMao();
        player2.calculaMao();
        Jogador atual = (turn == 0 ? player1 : player2);
        Jogador oponente = (turn == 0 ? player2 : player1);
        desenhaTela(atual);

        soma1.text = atual.getSoma().ToString() + "/21";
        soma2.text = "?/21";

        betUsuario.text = "Bet: " + atual.getBet().ToString();
        betAdversario.text = "Bet: " + oponente.getBet().ToString();

        vidaUsuario.text = "Vida: " + atual.getVida().ToString();
        vidaAdversario.text = "Vida: " + oponente.getVida().ToString();


        if(player1.getVida() ==0 || player2.getVida() == 0)
        {
            txt.text = "O vencedor foi o " + (turn == 0 ? "Jogador 1" : "Jogador 2");
            new WaitForSeconds(3f);
            resetarCena();
        }
        if(acaoBloqueada)
        {
            return;
        }
        if (contaPasse != 2)
        {
            if (atual.abrirInventario())
            {
                ToggleInventory(atual);
                onTrunfoinv(trunfosinv);
            }

            if (atual.comprarCarta(baralho))
            {
                contaPasse = 0;
                desenhaTela(atual);
            }

            if (atual.passarVez())
            {
                if (inventoryPanel.activeSelf)
                {
                    ToggleInventory(atual);
                }
                passarVez(atual);
                desenhaTela(atual);
                contaPasse += 1;
            }

        }
        else
        {
            StartCoroutine(DelayParaNovaRodada());
            contaPasse = 0;
            if(turn != 0)
            {
                atual = player1;
                oponente = player2;
            }
        }

        if (Input.GetKeyDown("e"))
        {
            TrunfoInvController a = trunfosinv.transform.GetChild(1).GetComponent<TrunfoInvController>();

            a.reseta();
        }
        

    }

    IEnumerator DelayParaNovaRodada()
    {
        acaoBloqueada = true;
            int somaPlayer1 = metaJogo - player1.getSoma();
            int somaPlayer2 = metaJogo - player2.getSoma();

            int vidaPlayer1 = player1.getVida();
            int vidaPlayer2 = player2.getVida();

            int betPlayer1 = player1.getBet();
            int betPlayer2 = player2.getBet();

            if (player1.getVida() == 0 || player2.getVida() == 0)
            {
                txt.text = "O vencedor foi o: " + (turn == 0 ? "Jogador 1" : "Jogador 2");
                yield return new WaitForSecondsRealtime(3f);
                resetarCena();
            }
            if(somaPlayer1 == somaPlayer2)
            {
                    txt.text = "Empate";
                    yield return new WaitForSecondsRealtime(3f);
            }
            else if (somaPlayer1 > 0 && somaPlayer2 > 0)
            {
                if (somaPlayer1 < somaPlayer2)
                {
                    txt.text = "Vencedor da rodada foi o jogador 1";
                    player2.setVida(vidaPlayer2 - betPlayer2);
                    yield return new WaitForSecondsRealtime(3f);

                }
                else
                {
                    txt.text = "Vencedor da rodada foi o jogador 2";
                    player1.setVida(vidaPlayer1 - betPlayer1);
                    yield return new WaitForSecondsRealtime(3f);

                }
                
            }
            else if (somaPlayer1 < 0 && somaPlayer2 >= 0)
            {
                txt.text = "Vencedor da rodada foi o jogador 2";
                player1.setVida(vidaPlayer1 - betPlayer1);
                yield return new WaitForSecondsRealtime(3f);
            }
            else if (somaPlayer2 < 0 && somaPlayer1 >= 0)
            {
                txt.text = "Vencedor da rodada foi o jogador 1";
                player2.setVida(vidaPlayer2 - betPlayer2);
                yield return new WaitForSecondsRealtime(3f);
            }
            else
            {
                if (somaPlayer1 > somaPlayer2)
                {
                    txt.text = "Vencedor da rodada foi o jogador 1";
                    player2.setVida(vidaPlayer2 - betPlayer2);
                    yield return new WaitForSecondsRealtime(3f);

                }
                else if (somaPlayer1 < somaPlayer2)
                {
                    txt.text = "Vencedor da rodada foi o jogador 2";
                    player1.setVida(vidaPlayer1 - betPlayer1);
                    yield return new WaitForSecondsRealtime(3f);

                }
                else
                {
                    txt.text = "Empate";
                    yield return new WaitForSecondsRealtime(3f);

                }
            }
            baralho = new Baralho();
            player1.reseta(baralho);
            player2.reseta(baralho);
            player1.setBet(1);
            player2.setBet(1);
            txt.text = "Seu Turno " +  (turn == 0 ? "Jogador 1" : "Jogador 2");
            acaoBloqueada = false;
    }

    public void ToggleInventory(Jogador atual)
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);
    }

    void passarVez(Jogador atual)
    {
        turn = (turn == 0) ? 1 : 0;
        txt.text = "Seu Turno ";
        txt.text += (turn == 0 ? "Jogador 1" : "Jogador 2");
        atual = (turn == 0 ? player1 : player2);
    }


    void limpaTela()
    {
        carta3.gameObject.SetActive(false);
        carta4.gameObject.SetActive(false);
        carta5.gameObject.SetActive(false);
        carta6.gameObject.SetActive(false);

        cartaVirada3.gameObject.SetActive(false);
        cartaVirada4.gameObject.SetActive(false);
        cartaVirada5.gameObject.SetActive(false);
        cartaVirada6.gameObject.SetActive(false);
    }
    void desenhaTela(Jogador atual)
    {
        limpaTela();
        CartaController c1 = carta1.GetComponent<CartaController>();
        c1.setSprite(atual.getMaoJogador()[0] - 1);

        CartaController c2 = carta2.GetComponent<CartaController>();
        c2.setSprite(atual.getMaoJogador()[1] - 1);

        if (atual.getMaoJogador().Count == 3)
        {
            carta3.gameObject.SetActive(true);
            

            CartaController c3 = carta3.GetComponent<CartaController>();
            c3.setSprite(atual.getMaoJogador()[2] - 1);
        }
        else if (atual.getMaoJogador().Count == 4)
        {
            carta3.gameObject.SetActive(true);
            carta4.gameObject.SetActive(true);

            CartaController c3 = carta3.GetComponent<CartaController>();
            c3.setSprite(atual.getMaoJogador()[2] - 1);
            CartaController c4 = carta4.GetComponent<CartaController>();
            c4.setSprite(atual.getMaoJogador()[3] - 1);
        }
        else if (atual.getMaoJogador().Count == 5)
        {
            carta3.gameObject.SetActive(true);
            carta4.gameObject.SetActive(true);
            carta5.gameObject.SetActive(true);

            CartaController c3 = carta3.GetComponent<CartaController>();
            c3.setSprite(atual.getMaoJogador()[2] - 1);
            CartaController c4 = carta4.GetComponent<CartaController>();
            c4.setSprite(atual.getMaoJogador()[3] - 1);
            CartaController c5 = carta5.GetComponent<CartaController>();
            c5.setSprite(atual.getMaoJogador()[4] - 1);

        }
        else if (atual.getMaoJogador().Count == 6)
        {
            carta3.gameObject.SetActive(true);
            carta4.gameObject.SetActive(true);
            carta5.gameObject.SetActive(true);
            carta6.gameObject.SetActive(true);
            CartaController c3 = carta3.GetComponent<CartaController>();
            c3.setSprite(atual.getMaoJogador()[2] - 1);
            CartaController c4 = carta4.GetComponent<CartaController>();
            c4.setSprite(atual.getMaoJogador()[3] - 1);
            CartaController c5 = carta5.GetComponent<CartaController>();
            c5.setSprite(atual.getMaoJogador()[4] - 1);
            CartaController c6 = carta6.GetComponent<CartaController>();
            c6.setSprite(atual.getMaoJogador()[5] - 1);
        }

        Jogador oponente = (turn == 0 ? player2 : player1);

        if (oponente.getMaoJogador().Count == 3)
        {
            cartaVirada3.gameObject.SetActive(true);
        }
        else if (oponente.getMaoJogador().Count == 4)
        {
            cartaVirada3.gameObject.SetActive(true);
            cartaVirada4.gameObject.SetActive(true);

        }
        else if (oponente.getMaoJogador().Count == 5)
        {
            cartaVirada3.gameObject.SetActive(true);
            cartaVirada4.gameObject.SetActive(true);
            cartaVirada5.gameObject.SetActive(true);

        }
        else if (oponente.getMaoJogador().Count == 6)
        {
            cartaVirada3.gameObject.SetActive(true);
            cartaVirada4.gameObject.SetActive(true);
            cartaVirada5.gameObject.SetActive(true);
            cartaVirada6.gameObject.SetActive(true);
        }
        // Debug.Log("Mao do jogador " + atual.getMaoJogador().Count);
    }



    private void onTrunfoinv(GameObject obj)
    {
        foreach (Transform filho in obj.transform)
        {
            filho.gameObject.SetActive(true);
        }
    }

    private void resetarCena()
    {
        SceneManager.LoadScene(cena);
    }


    public Jogador GetpAtual() { return (turn == 0 ? player1 : player2); }

    public Baralho GetBaralho() { return this.baralho; }

    public Jogador GetOponente() { return (turn == 0 ? player2 : player1); }

    public int getLifePlayer(){return (turn == 0 ? player1.getVida() : player2.getVida());}
    public int getLifeAdversario(){return (turn == 0 ? player2.getVida() : player1.getVida());}

}