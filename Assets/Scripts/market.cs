using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SearchService;
using System;

public class market : MonoBehaviour
{
    public int figsToSell;
    public float marketPrice;
    [SerializeField] private TextMeshProUGUI figsToSellText;
    [SerializeField] private TextMeshProUGUI sellValueText;
    [SerializeField] private TextMeshProUGUI marketPriceText;
    [SerializeField] private TextMeshProUGUI figsText;
    [SerializeField] private TextMeshProUGUI moneyText;
    private gameManager gameManager;
    private float sellValue;
    private System.Random random = new System.Random();

    private void Start()
    {
        marketPrice = 1f;
        figsToSell = 0;
        gameManager = FindObjectOfType<gameManager>();
        InvokeRepeating("GenerateMarketPrice", 0f, 5f);
    }
    private void Update()
    {
        UpdateText();
    }
    public void IncreaseFigsToSell()
    {
        if (figsToSell < gameManager.figs)
        {
            figsToSell += 1;
            
            
        }
    }

    public void DecreaseFigsToSell()
    {

        if (figsToSell > 0 )
        {
            figsToSell -= 1;
           
        }
    }
 

    void GenerateMarketPrice()
    {
        float minPrice = 0.5f;
        float maxPrice = 4.0f;

        float priceChange = (float)(random.NextDouble() * 0.3);
        float newPrice = marketPrice + priceChange;

        if (newPrice > maxPrice)
        {
            marketPrice = maxPrice;
        }
        else if (newPrice > minPrice)
        {
            marketPrice = (float)Math.Round(newPrice, 2);
        }
        else
        {
            while (newPrice <= minPrice)
            {
                priceChange = (float)(random.NextDouble() * 0.3);
                newPrice = marketPrice + priceChange;
            }

            marketPrice = (float)Math.Round(newPrice, 2);
        }

        
        
    }
    private void UpdateText()
    {
        sellValue = figsToSell * marketPrice;
        figsToSellText.text = figsToSell.ToString();
        sellValueText.text = sellValue.ToString("0.00") + "$";
        marketPriceText.text = "market value: " + marketPrice.ToString("0.00") + "$";
        moneyText.text = "Money: " + gameManager.money.ToString("0.00") + "$";
        figsText.text = "Figs: " + gameManager.figs.ToString();
    }
    public void sellFigs()
    {
        gameManager.figs -= figsToSell;
        gameManager.money += sellValue;
        figsToSell = 0;
    }



}
