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
    public float spawnTimer = 5;

    public List<GameObject> enemyObj;

    // Start is called before the first frame update
    void Start()
    {
        enemyObj = new List<GameObject>();
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

    public void AddEnemy(GameObject obj)
    {
        enemyObj.Add(obj);
    }

    public void RemoveEnemy(GameObject obj)
    {
        enemyObj.Remove(obj);
    }

    void SpawnEnemy()
    {
        var obj = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        obj.GetComponent<EnemyMovement>().spawner = this;
        AddEnemy(obj);
        if(enemyObj.Count < 20)
        {
            Invoke(nameof(EnemySpawnTimerReset), spawnTimer);
        }
        
    }

    void EnemySpawnTimerReset()
    {
        spawnPointSet = false;
    }

    public void TickUpDifficulty()
    {
        if(spawnTimer > 1)
        {
            spawnTimer = spawnTimer - 1;
        }
    }
}
