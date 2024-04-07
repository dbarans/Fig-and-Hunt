using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    
    public float money;
    [SerializeField] Items items;
    public int ammo;

    public void increaseFigs()
    {
        items.itemQuantities[0] += 1;
    }
    private void Update()
    {
        ammo = items.itemQuantities[1];
    }
    public void UpdateAmmo()
    {
        items.itemQuantities[1] = ammo;
    }




}
