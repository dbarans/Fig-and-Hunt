using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public float money;
    [SerializeField] Items items;
    [SerializeField] GameObject ammoPanel;
    public int ammo;

    public void increaseFigs()
    {
        items.itemQuantities[0] += 1;
    }

    private void Update()
    {
        ammo = items.itemQuantities[1];
        GameObject ammoQuantityText = ammoPanel.transform.GetChild(1).gameObject;

        if (ammoQuantityText != null)
        {
            TextMeshProUGUI textMeshPro = ammoQuantityText.GetComponent<TextMeshProUGUI>();

            if (textMeshPro != null)
            {
                textMeshPro.text = ammo.ToString();
            }
            else
            {
                Debug.LogError("TextMeshPro component not found!");
            }
        }
        else
        {
            Debug.LogError("Ammo Quantity Text GameObject not found!");
        }
    }

    public void UpdateAmmo()
    {
        items.itemQuantities[1] = ammo;
    }
}
