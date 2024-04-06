using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class market : MonoBehaviour
{
    public int figsToSell = 0;
    public float marketValue;
    [SerializeField] private TextMeshProUGUI figsToSellText;
    private gameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<gameManager>();
    }
    public void IncreaseFigsToSell()
    {
        if (figsToSell < gameManager.figs)
        {
            figsToSell += 1;
            figsToSellText.text = figsToSell.ToString();
        }
    }

    public void DecreaseFigsToSell()
    {

        if (figsToSell > 0 )
        {
            figsToSell -= 1;
            figsToSellText.text = figsToSell.ToString();
        }
    }


}
