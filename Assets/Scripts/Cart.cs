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
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Items items;
    private float value;

   
    private void Update()
    {
        UpdateEntry();
        value = entry1.quantity * entry1.price + entry2.quantity * entry2.price + entry3.quantity * entry3.price;
        valueText.text = "Total: " + value.ToString("0.00") + "$";
        moneyText.text = "Money: " + gameManager.money.ToString("0.00") + "$";

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
            items.item1Quantity += entry1.quantity;
            items.item2Quantity += entry2.quantity;
            items.item3Quantity += entry3.quantity;

            entry1.quantity = 0;
            entry2.quantity = 0;
            entry3.quantity = 0;

            
           
            


        }
       

    }
}
