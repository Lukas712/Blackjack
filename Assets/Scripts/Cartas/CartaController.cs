using UnityEngine;

public class CartaController : MonoBehaviour
{


    private Vector3 pos;


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
        transform.position = pos + new Vector3(0, 0.5f, 0);
    }
    void OnMouseExit()
    {
        transform.position = pos;
    }
}
