using UnityEngine;

public class TrunfoController : MonoBehaviour
{


    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sprite;
    private Vector3 pos;
    private Vector3 offset;

    private new SpriteRenderer renderer;
    //private TrunfoController trunfoTroca;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
        //trunfoTroca = null;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void setSprite(string desc)
    {


    }


    void OnMouseEnter()
    {
        Debug.Log("Colidiu");

    }

}
