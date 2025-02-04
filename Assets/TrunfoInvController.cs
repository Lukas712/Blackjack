using Unity.VisualScripting;
using UnityEngine;

public class TrunfoInvController : MonoBehaviour
{


    [SerializeField] private Sprite[] sprites;
    [SerializeField] GameObject trunfoinv1;
    [SerializeField] GameObject trunfoinv2;
    [SerializeField] GameObject trunfoinv3;
    [SerializeField] GameObject trunfoinv4;
    private int random;
    public static int cont = 0;
    private new SpriteRenderer renderer;
    private bool usado = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        random = Random.Range(0, 10);
        setSprite();
        trunfoinv1.SetActive(false);
        trunfoinv2.SetActive(false);
        trunfoinv3.SetActive(false);
        trunfoinv4.SetActive(false);
    }

    void setSprite()
    {
        this.renderer.sprite = sprites[random];
    }

    void OnMouseDown()
    {

        if (!usado)
        {
            if (cont < 4)
            {
                if (cont == 0)
                {
                    trunfoinv1.SetActive(true);
                    TrunfoController tf = trunfoinv1.GetComponent<TrunfoController>();
                    if (tf != null)
                    {
                        tf.setTrunfo(random);
                    }
                    else
                    {
                        Debug.Log("Ta nulo esse carai");
                    }

                }
                else if (cont == 1)
                {
                    random = Random.Range(0, 10);
                    trunfoinv2.SetActive(true);
                    TrunfoController tf = trunfoinv2.GetComponent<TrunfoController>();
                    if (tf != null)
                    {
                        tf.setTrunfo(random);
                    }

                }
                else if (cont == 2)
                {
                    random = Random.Range(0, 10);
                    trunfoinv3.SetActive(true);
                    TrunfoController tf = trunfoinv3.GetComponent<TrunfoController>();
                    if (tf != null)
                    {
                        tf.setTrunfo(random);
                    }
                }
                else if (cont == 3)
                {
                    random = Random.Range(0, 10);
                    trunfoinv4.SetActive(true);
                    TrunfoController tf = trunfoinv4.GetComponent<TrunfoController>();
                    if (tf != null)
                    {
                        tf.setTrunfo(random);
                    }
                }
                usado = true;
                cont++;
            }
        }

    }

    public void reseta()
    {
        trunfoinv1.SetActive(false);
        trunfoinv2.SetActive(false);
        trunfoinv3.SetActive(false);
        trunfoinv4.SetActive(false);
        cont = 0;
    }


}
