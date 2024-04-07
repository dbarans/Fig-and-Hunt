using UnityEngine;

public class Animal : MonoBehaviour
{
    private GameObject targetTree;
    [SerializeField] private TreeManager treeManager;
    [SerializeField] private float speed = 3f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (treeManager == null)
        {
            treeManager = FindObjectOfType<TreeManager>();
            if (treeManager == null)
            {
                Debug.LogError("TreeManager reference not set in Animal script!");
                return;
            }
        }

        GameObject[] trees = treeManager.trees;
        if (trees.Length > 0)
        {
            int randomIndex = Random.Range(0, trees.Length);
            targetTree = trees[randomIndex];
        }
    }

    void Update()
    {
        if (targetTree != null)
        {
            Vector3 direction = (targetTree.transform.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime);

           
            if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}

