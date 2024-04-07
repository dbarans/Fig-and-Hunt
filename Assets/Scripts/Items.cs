using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Items : MonoBehaviour
{
    [SerializeField] private List<Entry> items = new List<Entry>();
    [SerializeField] private gameManager gameManager;
    public int item1Quantity;
    public int item2Quantity;
    public int item3Quantity;
    public int item4Quantity;

    public void UpdateEntry()
    {
        if (item1Quantity <= 0)
        {
            
        }
    }
}
