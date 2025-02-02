using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CartaManager : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform initpos;


    private List<int> deck = new List<int>();





    void Start()
    {
        deck = new List<int>();
        for (int i = 0; i < 2; i++)
            AddCards();

        //pInit = new Vector3();
    }

    void Update()
    {

    }


    public void AddCards()
    {

        for (int i = 0; i < 2; i++)
        {
            //deck[i].transform.position = transform.position + new Vector3(1.5f * i, 0, 0);
        }


    }


    public void desenhaCarta()
    {

    }

}
