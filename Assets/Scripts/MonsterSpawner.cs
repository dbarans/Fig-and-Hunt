using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float minSpawnInterval = 1f; // Minimalny czas mi�dzy pojawieniami potwor�w
    public float maxSpawnInterval = 5f; // Maksymalny czas mi�dzy pojawieniami potwor�w
    public float spawnRadius = 5f;

    private float spawnTimer = 0f;
    private float nextSpawnTime; // Czas, w kt�rym pojawi si� nast�pny potw�r

    void Start()
    {
        nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= nextSpawnTime)
        {
            SpawnMonster();
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval); // Losowanie nowego czasu do nast�pnego potwora
            spawnTimer = 0f;
        }
    }

    void SpawnMonster()
    {
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(monsterPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}