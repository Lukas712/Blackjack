using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI trunfoTemplate;
    private List<Trunfo> trunfos;

    public InventoryController()
    {
        trunfos = new List<Trunfo>();
        inventoryPanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        bool isActive = inventoryPanel.activeSelf;
        inventoryPanel.SetActive(!isActive);

        if (!isActive)
        {
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            if (child != trunfoTemplate.transform)
                Destroy(child.gameObject);
        }
        foreach (Trunfo trunfo in trunfos)
        {
            TextMeshProUGUI newTrunfo = Instantiate(trunfoTemplate, inventoryPanel.transform);
            newTrunfo.text = trunfo.GetType().Name;
            newTrunfo.gameObject.SetActive(true);
        }
    }

    public void AddTrunfo(Trunfo trunfo)
    {
        trunfos.Add(trunfo);
    }

    public List<Trunfo> getInventario()
    {
        return trunfos;
    }
}
