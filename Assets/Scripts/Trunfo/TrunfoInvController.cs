using UnityEngine;
using TMPro;

public class TrunfoInvController : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] GameObject trunfoinv1;
    [SerializeField] GameObject trunfoinv2;
    [SerializeField] GameObject trunfoinv3;
    [SerializeField] GameObject trunfoinv4;
    [SerializeField] private TextMeshProUGUI descricao;

    private int random;
    private int cont = 0;
    private SpriteRenderer renderer;
    private bool usado = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        GerarNovoRandom();
        setSprite();
        DesativarTodosSlots();
    }

    void GerarNovoRandom()
    {
        random = Random.Range(0, 11);
    }

    void setSprite()
    {
        if (renderer != null && sprites.Length > random)
        {
            renderer.sprite = sprites[random];
        }
    }

    void OnMouseDown()
    {
        if (!usado && cont < 4)
        {
            GameObject slot = ObterSlotPorContador(cont);
            if (slot != null)
            {
                slot.SetActive(true);
                TrunfoController tf = slot.GetComponent<TrunfoController>();
                if (tf != null)
                {
                    tf.setTrunfo(random);
                }
                usado = true;
                cont++;
                GerarNovoRandom();
                setSprite();
            }
        }
    }

    GameObject ObterSlotPorContador(int index)
    {
        switch (index)
        {
            case 0: return trunfoinv1;
            case 1: return trunfoinv2;
            case 2: return trunfoinv3;
            case 3: return trunfoinv4;
            default: return null;
        }
    }

    public void reseta()
    {
        DesativarTodosSlots();
        cont = 0;
        usado = false;
        GerarNovoRandom();
        setSprite();
    }

    void DesativarTodosSlots()
    {
        trunfoinv1.SetActive(false);
        trunfoinv2.SetActive(false);
        trunfoinv3.SetActive(false);
        trunfoinv4.SetActive(false);
    }
}