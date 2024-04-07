using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites; // Tablica sprite'�w, kt�re maj� by� zmieniane
    [SerializeField] private float changeInterval = 1f; // Interwa� zmiany sprite'�w
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
            spriteRenderer.sprite = sprites[currentIndex]; // Ustawienie pocz�tkowego sprite'a
        }
    }

    void Update()
    {
        timer += Time.deltaTime; // Zwi�kszenie licznika czasu

        if (timer >= changeInterval)
        {
            ChangeSprite(); // Zmiana sprite'a, gdy up�ynie okre�lony czas
            timer = 0f; // Zresetowanie licznika czasu
        }
    }

    void ChangeSprite()
    {
        currentIndex = (currentIndex + 1) % sprites.Length; // Zwi�kszenie indeksu z zachowaniem granic tablicy
        spriteRenderer.sprite = sprites[currentIndex]; // Zmiana sprite'a na kolejny w tablicy
    }
}
