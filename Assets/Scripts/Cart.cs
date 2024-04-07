using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private entry entry1;
    [SerializeField] private entry entry2;
    [SerializeField] private entry entry3;
    [SerializeField] private gameManager gameManager;
    [SerializeField] private TextMeshProUGUI valueText;
    private float value;

    private void Start()
    {
       
    }
    private void Update()
    {
        UpdateEntry();
        value = entry1.quantity * entry1.price + entry2.quantity * entry2.price + entry3.quantity * entry3.price;
        valueText.text = "Total: " + value.ToString("0.00") + "$";

    }
    public void UpdateEntry()
    {
        if (entry1.quantity <= 0)
        {
            entry1.gameObject.SetActive(false);
        }
        else
        {
            entry1.gameObject.SetActive(true);
        }
        if (entry2.quantity <= 0)
        {
            entry2.gameObject.SetActive(false);
        }
        else
        {
            entry2.gameObject.SetActive(true);
        }
        if (entry3.quantity <= 0)
        {
            entry3.gameObject.SetActive(false);
        }
        else
        {
            entry3.gameObject.SetActive(true);
        }
    }
    
    public void Buy()
    {
        
        
        if (gameManager.money >= value)
        {
            gameManager.money -= value;
            gameManager.item1 += entry1.quantity;
            gameManager.item2 += entry2.quantity;
            gameManager.item3 += entry3.quantity;

            entry1.quantity = 0;
            entry2.quantity = 0;
            entry3.quantity = 0;

            value = 0;
            valueText.text = "Total: " + value.ToString("0.00") + "$";

        }
       

    }
}
