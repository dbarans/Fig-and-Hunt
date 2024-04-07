using UnityEngine;

public class FigTree : MonoBehaviour
{
    private TreeManager treeManager;

    void Start()
    {
        treeManager = FindObjectOfType<TreeManager>();

        if (treeManager == null)
        {
            Debug.LogError("No tree!");
        }
        else
        {
            treeManager.AddTree(gameObject);
        }
    }
}