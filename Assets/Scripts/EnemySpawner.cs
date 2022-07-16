using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnPointRange;
    Vector3 spawnPoint;
    bool spawnPointSet;
    public LayerMask whatIsGround;
    public float spawnTimer;
    int enemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPointSet == false)
        {
            SetSpawnPoint();
        }
    }
    void SetSpawnPoint()
    {
        float randomX = Random.Range(-spawnPointRange, spawnPointRange);
        float randomZ = Random.Range(-spawnPointRange, spawnPointRange);

        spawnPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(spawnPoint, -Vector3.up, 2f, whatIsGround))
        {
            spawnPointSet = true;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        enemies++;
        if(enemies <= 10)
        {
            Invoke(nameof(EnemySpawnTimerReset), spawnTimer);
        }
        
    }

    void EnemySpawnTimerReset()
    {
        spawnPointSet = false;
    }
}
