using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class entry : MonoBehaviour
{
    public int quantity;
    private float value;
    public float price;
    private gameManager gameManager;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private TextMeshProUGUI quantityText;

    private void Start()
    {
        gameManager = GetComponent<gameManager>();
    }
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
   
