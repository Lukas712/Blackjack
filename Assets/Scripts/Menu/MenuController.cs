using UnityEngine;

public class MenuController : MonoBehaviour
{


    [SerializeField] private GameObject telaInicial;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(true);
        telaInicial.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            this.gameObject.SetActive(false);
            telaInicial.gameObject.SetActive(true);
        }

    }
}
