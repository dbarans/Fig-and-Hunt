using System.Collections;
using UnityEngine;

public class FigTree : MonoBehaviour
{
    [SerializeField]
    private GameObject[] fruits;

    private void Start()
    {
        foreach (GameObject fruit in fruits)
        {
            float randomTime = Random.Range(2f, 5f);
            Invoke("ChangeFruitState", randomTime);
        }
    }

    private void ChangeFruitState()
    {
        GameObject fruit = fruits[Random.Range(0, fruits.Length)];
        if (fruit.transform.GetChild(0).gameObject.activeSelf && !fruit.transform.GetChild(1).gameObject.activeSelf)
        {
            SetFruitState3(fruit);
        }
        else if (!fruit.transform.GetChild(0).gameObject.activeSelf && fruit.transform.GetChild(1).gameObject.activeSelf)
        {
            // This is the last state, no need to continue state changes
            return;
        }
        else
        {
            int nextState = Random.Range(1, 3); // Randomly choose between state 1 and state 2
            if (nextState == 1)
                SetFruitState1(fruit);
            else
                SetFruitState2(fruit);

            float randomTime = Random.Range(2f, 5f); // Generate a new random time for the next state change
            Invoke("ChangeFruitState", randomTime); // Invoke again for the next state change
        }
    }

    private void SetFruitState1(GameObject fruit)
    {
        fruit.transform.GetChild(0).gameObject.SetActive(false);
        fruit.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void SetFruitState2(GameObject fruit)
    {
        fruit.transform.GetChild(0).gameObject.SetActive(true);
        fruit.transform.GetChild(1).gameObject.SetActive(false);
    }

    private void SetFruitState3(GameObject fruit)
    {
        fruit.transform.GetChild(0).gameObject.SetActive(false);
        fruit.transform.GetChild(1).gameObject.SetActive(true);
    }
}
