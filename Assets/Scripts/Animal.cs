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

        FindRandomTree();
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
        else
        {
            SearchNearestTree();
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("destroy fox");
        Destroy(gameObject);
    }

    void FindRandomTree()
    {
        GameObject[] trees = treeManager.trees;
        if (trees.Length > 0)
        {
            int randomIndex = Random.Range(0, trees.Length);
            targetTree = trees[randomIndex];
        }
    }

    void SearchNearestTree()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 200f); // Ustaw promieñ wyszukiwania

        float minDistance = Mathf.Infinity;
        GameObject nearestTree = null;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Tree"))
            {
                GameObject tree = collider.gameObject;
                float distance = Vector3.Distance(transform.position, tree.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTree = tree;
                }
            }
        }

        if (nearestTree != null)
        {
            targetTree = nearestTree;
        }
    }
}
