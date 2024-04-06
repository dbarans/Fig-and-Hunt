using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform windowsOneTrans;
    [SerializeField] Transform windowsTwoTrans;
    [SerializeField] Transform windowsThreeTrans;
    [SerializeField] Transform roomDefTrans;
    [SerializeField] Camera cam;
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
                Debug.Log(gameObject);
                CurrentClickedGameObject(clickedObject);
                // Handle interaction based on the clickedObject
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            cam.transform.DOMove(new Vector3(roomDefTrans.position.x, roomDefTrans.position.y, roomDefTrans.position.z), time );

        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        Debug.Log(gameObject.tag + " " + gameObject.name);
        if(gameObject.tag=="WindowOne")
        {
            cam.transform.DOMove(new Vector3(windowsOneTrans.position.x, windowsOneTrans.position.y, windowsOneTrans.position.z), time );
        }
        Debug.Log(gameObject.tag + " " + gameObject.name);
        if (gameObject.tag == "WindowTwo") 
        {
            cam.transform.DOMove(new Vector3(windowsTwoTrans.position.x, windowsTwoTrans.position.y, windowsTwoTrans.position.z), time );
        }
        Debug.Log(gameObject.tag + " " + gameObject.name);
        if(gameObject.tag=="WindowThree")
        {
            cam.transform.DOMove(new Vector3(windowsThreeTrans.position.x, windowsThreeTrans.position.y, windowsThreeTrans.position.z), time );
        }
    }
}
