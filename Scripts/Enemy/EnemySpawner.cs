using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject CharacterPrefab;
    [SerializeField] private float SpawnPeriod;

    private float _lastSpawnTime = 0;

    void Update()
    {
        ProcessEnemySpawn();
    }

    public void ProcessEnemySpawn()
    {
        if (Time.time - _lastSpawnTime > SpawnPeriod)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);

        _lastSpawnTime = Time.time;
    }
}
