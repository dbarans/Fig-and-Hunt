using UnityEngine;
using UnityEngine.UI; // Make sure to add this namespace if you're working with UI elements

public class Store : MonoBehaviour
{
    public GameObject entry1;
    public GameObject entry2;
    public GameObject entry3;
    public int entry1_quantity = 0;
    public int entry2_quantity = 0;
    public int entry3_quantity = 0;

    public void addItem(int entry_number)
    {
        switch (entry_number)
        {
            case 1:
                entry1_quantity++;
                break;
            case 2:
                entry2_quantity++;
                break;
            case 3:
                entry3_quantity++;
                break;
        }
    }

    private void UpdateEntry()
    {
        Text textComponent = null;
        foreach (Transform child in entry1.transform)
        {
            if (child.name == "TextQuantity")
            {
                textComponent = child.GetComponent<Text>();
                break;
            }
        }

        
    }
}
