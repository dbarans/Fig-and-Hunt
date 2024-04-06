using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]Transform windowsOne;
    [SerializeField]Transform windowsTwo;
    [SerializeField]Transform windowsThree;
    [SerializeField] Camera cam;

    void Update()
     {
            //Check for mouse click 
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out raycastHit, 100f))
                {
                    if (raycastHit.transform != null)
                    {
                       //Our custom method. 
                        CurrentClickedGameObject(raycastHit.transform.gameObject);
                    }
                }
            }
     }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if(gameObject.tag=="windows1")
        {
        }
        Debug.Log(gameObject.tag + " " + gameObject.name);
        if(gameObject.tag=="windows1")
        {
            Do
        }
        Debug.Log(gameObject.tag + " " + gameObject.name);
        if(gameObject.tag=="window1")
        {
        }
        Debug.Log(gameObject.tag + " " + gameObject.name);
    }
}
