using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float minSpawnInterval = 1f; // Minimalny czas miêdzy pojawieniami potworów
    public float maxSpawnInterval = 5f; // Maksymalny czas miêdzy pojawieniami potworów
    public float spawnRadius = 5f;

    private float spawnTimer = 0f;
    private float nextSpawnTime; // Czas, w którym pojawi siê nastêpny potwór

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
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval); // Losowanie nowego czasu do nastêpnego potwora
            spawnTimer = 0f;
        }
    }

    void SpawnMonster()
    {
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
        Instantiate(monsterPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}