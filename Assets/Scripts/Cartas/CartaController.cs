
using UnityEngine;

public class CartaController : MonoBehaviour
{


    private UnityEngine.Vector3 pos;
    private UnityEngine.Vector3 offset;
    private bool segurando = false;
    [SerializeField] private Sprite[] sprites;
    private new SpriteRenderer renderer;
    private CartaController cartaTroca;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[0];
        pos = transform.position;
        cartaTroca = null;
        // Debug.Log("Teste");
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnMouseEnter()
    {
        if (!segurando)
            transform.position = pos + new UnityEngine.Vector3(0, 0.3f, 0);

    }
    void OnMouseExit()
    {



        if (!segurando)
            transform.position = pos;
    }

    void OnMouseUp()
    {
        segurando = false;
        if (cartaTroca != null)
            swapPo(cartaTroca);
        else
            transform.position = pos;
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        segurando = true;
    }

    void OnMouseDrag()
    {
        if (segurando)
        {
            UnityEngine.Vector3 nPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            nPos.z = 0;
            transform.position = nPos;
        }
    }

    public void setSprite(int i)
    {
        renderer.sprite = sprites[i];
    }


    private void OnTriggerEnter2D(Collider2D obj)
    {
        CartaController temp = obj.GetComponent<CartaController>();
        if (temp != null && temp != this)
            cartaTroca = temp;
    }



    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.GetComponent<CartaController>() == cartaTroca)
            cartaTroca = null;
    }

    private void swapPo(CartaController carta)
    {
        UnityEngine.Vector3 tempPos = pos;
        pos = carta.pos;
        carta.pos = tempPos;

        transform.position = pos;
        carta.transform.position = carta.pos;

    }


}
