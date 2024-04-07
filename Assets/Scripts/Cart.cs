using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] private entry entry1;
    [SerializeField] private entry entry2;
    [SerializeField] private entry entry3;
    [SerializeField] private gameManager gameManager;
    private float value;

    private void Start()
    {
       
    }
    private void Update()
    {
        UpdateEntry();
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
            gameManager.item1 += entry1.quantity;
            gameManager.item2 += entry2.quantity;
            gameManager.item3 += entry3.quantity;
            entry1.quantity = 0;
            entry2.quantity = 0;
            entry3.quantity = 0;
            gameManager.money -= value;
        }

    }
}
