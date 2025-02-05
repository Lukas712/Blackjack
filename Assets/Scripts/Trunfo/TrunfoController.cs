using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class TrunfoController : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMeshProUGUI descricao;
    private SpriteRenderer sprite;
    private Vector3 pos;
    private Vector3 offset;
    private bool segurando = false;
    private new SpriteRenderer renderer;
    private BetUm aumentar1;
    private BetDois aumentar2;
    private DiminuiBetUm diminuir1;
    private DiminuiBetDois diminuir2;
    [SerializeField] private GameController gameController;
    private bool usado = false;
    private int valorTrunfo;


    private Trunfo atual;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        atual = null;
        if (renderer == null)
            Debug.Log("renderer = nulo");
        pos = transform.position;
        valorTrunfo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  


    public void setSprite(int i)
    {
        renderer.sprite = sprites[i];
    }


    public void setTrunfo(int random)
    {
        valorTrunfo = random;

        switch (random)
        {

            case 0:
                atual = (CompraUm)atual;
                atual = new CompraUm();
                setSprite(0);
                break;

            case 1:
                atual = (CompraDois)atual;
                atual = new CompraDois();
                setSprite(1);
                break;

            case 2:
                atual = (CompraTres)atual;
                atual = new CompraTres();
                setSprite(2);
                break;

            case 3:
                atual = (CompraQuatro)atual;
                atual = new CompraQuatro();
                setSprite(3);
                break;

            case 4:
                atual = (CompraCinco)atual;
                atual = new CompraCinco();
                setSprite(4);
                break;

            case 5:
                atual = (CompraSeis)atual;
                atual = new CompraSeis();
                setSprite(5);
                break;

            case 6:
                atual = (CompraSete)atual;
                atual = new CompraSete();
                setSprite(6);
                break;

            case 7:
                atual = (DiminuiBetUm)atual;
                atual = new DiminuiBetUm();
                setSprite(7);
                break;

            case 8:
                atual = (DiminuiBetDois)atual;
                atual = new DiminuiBetDois();
                setSprite(8);
                break;

            case 9:
                atual = (BetUm)atual;
                atual = new BetUm();
                setSprite(9);
                break;
            case 10:
                atual = (BetDois)atual;
                atual = new BetDois();
                setSprite(10);
                break;
            default:
                break;
        }




    }



    void OnMouseDown()
    {   
        if(atual != null && !usado)
        {
            atual.efeitoTrunfo(gameController.GetBaralho(), gameController.GetpAtual(), gameController.GetOponente());
            descricao.SetText(atual.descricaoTrunfo());
            usado = true;
        }
    }

}
