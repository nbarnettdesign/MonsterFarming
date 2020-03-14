using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRoom : MonoBehaviour
{
    public bool hasSpawner;
    public float chestSpawnChance = 10f;
    public float EnemySpawnChance = 5f;
    public GameObject chestPrefab;
    public List<GameObject> RoomFixins;
    public List<GameObject> RoomSpawners;
    public List<Transform> RoomSpawnerLocations;
    public List<Transform> RoomChestLocations;

    void Start()
    {
        float isSpawner = Random.Range(0f, 100f);

        if (isSpawner <= EnemySpawnChance)
        {
            if (hasSpawner)
            {
                //might need to change to based off of the type of room fixins it has or something
                int spawner = Random.Range(0, RoomSpawners.Count);
                int spawnerLocation = Random.Range(0, RoomSpawnerLocations.Count);
                Instantiate(RoomSpawners[spawner], RoomSpawnerLocations[spawnerLocation]);
            }
        }

        float isChest = Random.Range(0f, 100f);

        if (isChest <= chestSpawnChance)
        {
            int chestLocation = Random.Range(0, RoomSpawnerLocations.Count);
            Instantiate(chestPrefab, RoomSpawnerLocations[chestLocation]);
        }

        int roomContents = Random.Range(0, RoomFixins.Count);
        Instantiate(RoomFixins[roomContents],this.transform.position, this.transform.rotation);

    }
}