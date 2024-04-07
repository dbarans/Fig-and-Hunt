using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public GameObject[] trees;

    void Awake()
    {
        trees = new GameObject[0];
    }

    void Update()
    {
        GameObject[] activeTrees = new GameObject[trees.Length];
        int activeTreeCount = 0;

        for (int i = 0; i < trees.Length; i++)
        {
            if (trees[i].activeSelf)
            {
                activeTrees[activeTreeCount] = trees[i];
                activeTreeCount++;
            }
            else
            {
                Destroy(trees[i]);
            }
        }

        trees = new GameObject[activeTreeCount];
        for (int i = 0; i < activeTreeCount; i++)
        {
            trees[i] = activeTrees[i];
        }
    }

    public void AddTree(GameObject tree)
    {
        int newSize = trees.Length + 1;
        GameObject[] newTrees = new GameObject[newSize];

        for (int i = 0; i < trees.Length; i++)
        {
            newTrees[i] = trees[i];
        }

        newTrees[newSize - 1] = tree;
        trees = newTrees;
    }
}
