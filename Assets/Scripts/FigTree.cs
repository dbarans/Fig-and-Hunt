using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FigTree : MonoBehaviour
{
    private TreeManager treeManager;
    private GameObject[] fruits;
    private Dictionary<GameObject, Coroutine> eatingCoroutines = new Dictionary<GameObject, Coroutine>();
    private HashSet<GameObject> foxesInside = new HashSet<GameObject>(); // Zbiór przechowuj¹cy referencje do wszystkich lisi wewn¹trz obszaru kolizji

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
        if (collision.gameObject.CompareTag("Fox") && !IsEating(collision.gameObject))
        {
            Coroutine coroutine = StartCoroutine(EatFruits());
            eatingCoroutines.Add(collision.gameObject, coroutine);
            foxesInside.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(eatingCoroutines[collision.gameObject]);
        if (collision.gameObject.CompareTag("Fox"))
        {
            foxesInside.Remove(collision.gameObject);
            if (foxesInside.Count == 0) 
            {
                CheckForNewFruits(); 
            }
            else
            {

                FoxDestroy(collision.gameObject); 
            }
        }
    }

    IEnumerator EatFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            fruit.GetComponent<Fruit>().Eat();
            yield return new WaitForSeconds(0.3f);
        }
        DestroyTree();
    
    }

    void CheckForNewFruits()
    {
        foreach (GameObject fruit in fruits)
        {
            if (fruit.activeSelf)
            {
                StartCoroutine(EatFruit(fruit));
                return;
            }
        }

      
        DestroyTree();
    }

    IEnumerator EatFruit(GameObject fruit)
    {
        fruit.GetComponent<Fruit>().Eat();
        yield return new WaitForSeconds(0.3f);
    }

    void DestroyTree()
    {
        Debug.Log("Destroying tree...");
        gameObject.SetActive(false);
    }

    void FoxDestroy(GameObject fox)
    {
        if (eatingCoroutines.ContainsKey(fox))
        {
            StopCoroutine(eatingCoroutines[fox]);
            eatingCoroutines.Remove(fox);
        }
    }

    bool IsEating(GameObject fox)
    {
        return eatingCoroutines.ContainsKey(fox);
    }
}
