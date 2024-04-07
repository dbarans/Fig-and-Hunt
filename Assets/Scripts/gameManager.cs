using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [HideInInspector]
    public int figs;
    public float money;
    public int item1;
    public int item2;
    public int item3;
    public float item1Price;
    public float item2Price;
    public float item3Price;

    private void Awake()
    {
        figs = 5;
    }
    void Start()
    {
        
    }


    void Update()
    {
        Debug.Log(money);
    }
  
}
