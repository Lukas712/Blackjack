using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{


    [SerializeField] private GameObject telaInicial;
    [SerializeField] private TextMeshProUGUI pressbutton;
    private float tempo;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(true);
        telaInicial.SetActive(false);

        pressbutton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (tempo > 1f)
            pressbutton.gameObject.SetActive(true);

        if (Input.anyKeyDown && tempo > 1.5f)
        {
            this.gameObject.SetActive(false);
            telaInicial.gameObject.SetActive(true);
        }
        tempo += Time.deltaTime;

    }
}
