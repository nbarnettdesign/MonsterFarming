using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<GameObject> tiles;
    public int maxRooms;
    public int currentRooms;
    public int minRooms;
    GameObject lastTile;
    float timer;
    bool hasAnEnding;
    public GameObject dungeonEndTile;

    private void Start()
    {
        hasAnEnding = false;
        currentRooms = 1;
    }

    public void MakeATile(Transform exitPoint,GameObject thisTile)
    {
        if(maxRooms >= currentRooms)
        {
            int prefabRand = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[prefabRand], exitPoint);
            currentRooms += 1;
            lastTile = thisTile;
            timer = .2f;
        }

    }

    public void EndGame(Transform exitPoint)
    {
        Instantiate(dungeonEndTile, exitPoint);
    }


    private void Update()
    {
        if (!hasAnEnding)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                for (int i = tiles.Count-1; i > 0; i--)
                {
                    if (tiles[i].GetComponent<DungeonTiles>().canHaveExit == true)
                    {
                        tiles[i].GetComponent<DungeonTiles>().DungeonEnd();
                        hasAnEnding = true;
                        break;
                    }
                }
            }
        }

    }
}
