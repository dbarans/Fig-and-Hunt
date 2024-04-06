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
    [SerializeField] float time;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
                }
                if(clickedObject.name == "Window2")
                {
                    camRoom.gameObject.SetActive(false);
                    camFieldTwo.gameObject.SetActive(true);
                }
                if(clickedObject.name == "Window3")
                {
                    camRoom.gameObject.SetActive(false);
                    camFieldThree.gameObject.SetActive(true);
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
        }
    }

}
