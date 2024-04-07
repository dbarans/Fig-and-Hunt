using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float changeInterval = 1f;
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;
    private float timer = 0f;
    public bool isFreeze;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned!");
            isFreeze = false;
        }
        else
        {
            spriteRenderer.sprite = sprites[currentIndex];
        }
    }
        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= changeInterval)
            {
                ChangeSprite();
                timer = 0f;
            }
        }

        void ChangeSprite()
        {
            if (!isFreeze)
            {
                currentIndex = (currentIndex + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentIndex];
            }
        }
    }

