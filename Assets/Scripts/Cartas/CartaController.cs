using UnityEngine;

public class CartaController : MonoBehaviour
{


    private Vector3 pos;
    private Vector3 offset;
    private bool segurando = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            transform.position = pos + new Vector3(0, 0.5f, 0);
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


}
