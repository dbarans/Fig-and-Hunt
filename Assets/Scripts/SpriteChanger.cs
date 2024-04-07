using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites; // Tablica sprite'ów, które maj¹ byæ zmieniane
    [SerializeField] private float changeInterval = 1f; // Interwa³ zmiany sprite'ów
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0; // Indeks aktualnie wybranego sprite'a
    private float timer = 0f; // Licznik czasu

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (sprites.Length == 0)
        {
            Debug.LogError("No sprites assigned!");
        }
        else
        {
            spriteRenderer.sprite = sprites[currentIndex]; // Ustawienie pocz¹tkowego sprite'a
        }
    }

    void Update()
    {
        timer += Time.deltaTime; // Zwiêkszenie licznika czasu

        if (timer >= changeInterval)
        {
            ChangeSprite(); // Zmiana sprite'a, gdy up³ynie okreœlony czas
            timer = 0f; // Zresetowanie licznika czasu
        }
    }

    void ChangeSprite()
    {
        currentIndex = (currentIndex + 1) % sprites.Length; // Zwiêkszenie indeksu z zachowaniem granic tablicy
        spriteRenderer.sprite = sprites[currentIndex]; // Zmiana sprite'a na kolejny w tablicy
    }
}
