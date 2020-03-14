using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Spawner;
    public List<GameObject> enemyPrefab;

    public int enemyTotal;
    public int enemyMax;

    public bool continuousSpawning = true;
    bool spawning;
    public float spawnTimerMin;
    public float spawnTimerMax;
    float spawnTime;
    float spawnTimer;
    public float spawnRadius;
    GameObject spawner;

    private void Start()
    {
        spawner = this.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if(enemyTotal < enemyMax && !spawning)
        {
            spawning = true;
            spawnTimer = 0;
            spawnTime = Random.Range(spawnTimerMin, spawnTimerMax);
        }

        if (spawning)
        {
            if (spawnTimer < spawnTime)
            {
                spawnTimer += Time.deltaTime;
            }
            else
            {
                spawnTimer = 0;
                spawning = false;
                GameObject enemySpawned = Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Count - 1)], transform.position, Quaternion.identity);
                enemySpawned.GetComponent<EnemyStats>().spawner = spawner;
                enemySpawned.GetComponent<EnemyController>().WanderAround(spawnRadius);
            }
        }


    }

    public void Enemykilled()
    {
        enemyTotal -= 1;
        if (!continuousSpawning)
        {
            enemyMax -= 1;
        }
    }
}
