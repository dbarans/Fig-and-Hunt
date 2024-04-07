using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Items : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<int> itemQuantities = new List<int>();
    
    private void Update()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Transform quantityTransform = items[i].transform.GetChild(2);
            TextMeshProUGUI quantityText = quantityTransform.GetComponent<TextMeshProUGUI>();
            quantityText.text = itemQuantities[i].ToString();

            if (itemQuantities[i] <= 0)
            {
                items[i].SetActive(false);
            }
            else
            {
                items[i].SetActive(true);
            }

            
        }
    }
}
