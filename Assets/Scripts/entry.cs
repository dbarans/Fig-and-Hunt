using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class entry : MonoBehaviour
{
    public int quantity;
    public float value;
    public float price;
    [SerializeField] private gameManager gameManager;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI quantityText;

  
    public void IncreaseQuantity()
    {
        quantity += 1;
    }
    private void Update()
    {
        value = quantity * price;
        valueText.text = value.ToString("0.00") + "$";
        quantityText.text = quantity.ToString();


    }


}
   
