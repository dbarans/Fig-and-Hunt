using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private int currentState = 1;

    public float minTime = 3f;
    public float maxTime = 7f;

    private IEnumerator currentCoroutine;

    private void Start()
    {
        SetFruitState1();
        StartChangeStateCoroutine();
    }

    private void StartChangeStateCoroutine()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = ChangeStateAfterRandomDelay();
        StartCoroutine(currentCoroutine);
    }

    private void SetFruitState1()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        currentState = 1;
    }

    private void SetFruitState2()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        currentState = 2;
    }

    private void SetFruitState3()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        currentState = 3;
    }

    private IEnumerator ChangeStateAfterRandomDelay()
    {
        float delay = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(delay);

        if (currentState == 1)
        {
            SetFruitState2();
        }
        else if (currentState == 2)
        {
            SetFruitState3();
        }
       

        StartChangeStateCoroutine(); 
    }
}
