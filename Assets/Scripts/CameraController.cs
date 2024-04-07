using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera camRoom;
    [SerializeField] Camera camFieldOne;
    [SerializeField] Camera camFieldTwo;
    [SerializeField] Camera camFieldThree;
    [SerializeField] GameObject computer;
    [SerializeField] float time;
    private bool isInMainRoom;

    private void Start()
    {
        isInMainRoom = true;
    }
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0) && isInMainRoom)
        { // Left click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                Debug.Log(clickedObject.name);
                if(clickedObject.name == "Window1")
                {
                    camRoom.gameObject.SetActive(false);
                    camFieldOne.gameObject.SetActive(true);
                    isInMainRoom = false;
                }
                if(clickedObject.name == "Window2")
                {
                    camRoom.gameObject.SetActive(false);
                    camFieldTwo.gameObject.SetActive(true);
                    isInMainRoom = false;

                    }
                    if (clickedObject.name == "Window3")
                {
                    camRoom.gameObject.SetActive(false);
                    camFieldThree.gameObject.SetActive(true);
                    isInMainRoom = false;

                    }
                    if (clickedObject.name =="Computer")
                {
                    Debug.Log("computer clicked");
                    computer.gameObject.SetActive(true);
                     isInMainRoom = false;

                    }
                }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse button two");
            camRoom.gameObject.SetActive(true);
            camFieldOne.gameObject.SetActive(false);
            camFieldTwo.gameObject.SetActive(false);
            camFieldThree.gameObject.SetActive(false);
            computer.gameObject.SetActive(false);
            isInMainRoom = true;
        }
    }

}
