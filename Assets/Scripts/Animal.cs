using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.Rendering;

public class Animal : MonoBehaviour
{
    private GameObject targetTree;
    [SerializeField] private TreeManager treeManager;
    [SerializeField] private float speed = 3f;
    private SpriteRenderer spriteRenderer;
    private SoundManager soundManager;
    [SerializeField] private gameManager gameManager;
    private bool isFrozen = false; 
    private SpriteChanger changer;

    void Start()
    {
        changer = GetComponent<SpriteChanger>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundManager = FindAnyObjectByType<SoundManager>();
        gameManager = FindAnyObjectByType<gameManager>();

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
        if (!isFrozen)
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
    }

    private void OnMouseDown()
    {
        if (gameManager.ammo > 0) 
        {
            Destroy(gameObject);
            soundManager.PlayGunshotSound();
            gameManager.ammo -= 1;
            gameManager.UpdateAmmo();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Tree"))
        {
            isFrozen = true;
            changer.isFreeze = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            isFrozen = false;
            changer.isFreeze = false;
        }
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 200f);
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
