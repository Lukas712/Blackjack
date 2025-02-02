using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CartaManager : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    

    private List<GameObject> deck = new List<GameObject>();




    
    void Start()
    {
        for (int i = 0; i < 2; i++)
            AddCards();

        //pInit = new Vector3();
    }

    void Update()
    {
        
    }


    public void AddCards()
    {
        

    }


    public void desenhaCarta()
    {

    }

}
