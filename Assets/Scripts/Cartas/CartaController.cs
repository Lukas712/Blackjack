using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class CartaController : MonoBehaviour
{


    private Vector3 pos;
    private Vector3 offset;
    private bool segurando = false;
    public bool standby = false;
    [SerializeField] private Sprite[] sprites;
    private new SpriteRenderer renderer;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[0];
        pos = transform.position;
        Debug.Log("Teste");
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnMouseEnter()
    {
        if (!segurando)
            transform.position = pos + new Vector3(0, 0.3f, 0);

    }
    void OnMouseExit()
    {



        if (!segurando)
            transform.position = pos;
    }

    void OnMouseUp()
    {
        segurando = false;
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
            Vector3 nPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            nPos.z = 0;
            transform.position = nPos;
        }
    }

    public void setSprite(int i)
    {
        renderer.sprite = sprites[i];
    }


}
