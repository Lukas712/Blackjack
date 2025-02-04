using Unity.VisualScripting;
using UnityEngine;

public class TrunfoController : MonoBehaviour
{


    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sprite;
    private Vector3 pos;
    private Vector3 offset;
    private bool segurando = false;
    private new SpriteRenderer renderer;
    private AumentaBetUm aumentar1;
    private AumentaBetDois aumentar2;
    private DiminuiBetUm diminuir1;
    private DiminuiBetDois diminuir2;
    private GameController gameController;
    private bool usado = false;


    private Trunfo atual;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();

        if (renderer == null)
            Debug.Log("renderer = nulo");
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseEnter()
    {
        //Debug.Log("Colidiu");

    }


    public void setSprite(int i)
    {
        renderer.sprite = sprites[i];
    }


    public void setTrunfo(int random)
    {

        switch (random)
        {


            case 0:
                atual = new CompraUm();
                setSprite(0);
                break;

            case 1:
                atual = new CompraDois();
                setSprite(1);
                break;

            case 2:
                atual = new CompraTres();
                setSprite(2);
                break;

            case 3:
                atual = new CompraQuatro();
                setSprite(3);
                break;

            case 4:
                atual = new CompraCinco();
                setSprite(4);
                break;

            case 5:
                atual = new CompraSeis();
                setSprite(5);
                break;

            case 6:
                atual = new CompraSete();
                setSprite(6);
                break;

            case 7:
                atual = new DiminuiBetUm();
                setSprite(7);
                break;

            case 8:
                atual = new DiminuiBetDois();
                setSprite(8);
                break;

            case 9:
                atual = new AumentaBetUm();
                setSprite(9);
                break;
            case 10:
                atual = new AumentaBetDois();
                setSprite(10);
                break;
        }




    }



    void OnMouseDown()
    {

        //ao clicar no trunfo, ativa ele...
        if (atual != null && !usado)
        {
            
            atual.efeitoTrunfo(gameController.GetBaralho(), gameController.GetpAtual(), gameController.GetOponente());
            usado = true;
        }
    }

}
