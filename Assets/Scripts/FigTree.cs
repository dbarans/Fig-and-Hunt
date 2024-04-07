using UnityEngine;
using System.Collections;

public class FigTree : MonoBehaviour
{
    private TreeManager treeManager;
    private GameObject[] fruits;
    private bool isEating = false;

    void Start()
    {
        treeManager = FindObjectOfType<TreeManager>();

        if (treeManager == null)
        {
            Debug.LogError("No tree manager found!");
        }
        else
        {
            treeManager.AddTree(gameObject);
        }

        fruits = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            fruits[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fox" && !isEating)
        {
            StartCoroutine(EatFruits());
        }
    }

    IEnumerator EatFruits()
    {
        isEating = true;

        foreach (GameObject fruit in fruits)
        {
            fruit.GetComponent<Fruit>().Eat();
            yield return new WaitForSeconds(2f);
        }

        isEating = false;

        CheckForNewFruits();
    }

    void CheckForNewFruits()
    {
        fruits = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            fruits[i] = transform.GetChild(i).gameObject;
        }

        bool foundNewFruits = false;

        foreach (GameObject fruit in fruits)
        {
            if (fruit.activeSelf)
            {
                foundNewFruits = true;
                StartCoroutine(EatFruit(fruit));
                DestroyTree();
            }
        }

        
    }

    IEnumerator EatFruit(GameObject fruit)
    {
        fruit.GetComponent<Fruit>().Eat();
        yield return new WaitForSeconds(2f);
    }

    void DestroyTree()
    {
        Debug.Log("Destroying tree...");
        gameObject.SetActive(false);
    }
}
