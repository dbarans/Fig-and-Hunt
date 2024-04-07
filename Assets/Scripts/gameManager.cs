using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    
    public float money;
    [SerializeField] Items items;

    public void increaseFigs()
    {
        items.itemQuantities[0] += 1;
    }


  


}
