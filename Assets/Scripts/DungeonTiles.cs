using System.Collections.Generic;
using UnityEngine;

public class DungeonTiles : MonoBehaviour
{
    public List<Transform> points;
    public Transform entryPoint;
    public Transform exitPoint;
    public GameObject controller;
    public List<Transform> usedPoints;
    int exitsNeeded;
    int exitsUsed;
    public GameObject roomSpawner;
    GameObject thisTile;
    Collider thisCollider;
    List<GameObject> tiles;
    public bool canHaveExit = true;
    

    void Start()
    {
        canHaveExit = true;
        controller = GameObject.FindGameObjectWithTag("DungeonController");
        tiles = controller.GetComponent<DungeonController>().tiles;
        thisTile = this.gameObject;

        if (thisTile != null)
        {
            thisCollider = thisTile.GetComponent<Collider>();
            controller.GetComponent<DungeonController>().tiles.Add(thisTile);
        }
        exitsUsed = 0;
        exitsNeeded = Random.Range(0, points.Count);
        controller = GameObject.FindGameObjectWithTag("DungeonController");
        if(exitsNeeded == 0)
        {
            if(controller.GetComponent<DungeonController>().currentRooms <= 
            controller.GetComponent<DungeonController>().minRooms && points.Count != 0)
            {
                exitsNeeded = Random.Range(1, points.Count);
            }
        }
        for (int i = 0; i < controller.GetComponent<DungeonController>().tiles.Count; i++)
        {
            if (thisTile != null)
            {
                if (thisTile != controller.GetComponent<DungeonController>().tiles[i])
                {
                    if (thisCollider.bounds.Intersects(controller.GetComponent<DungeonController>().tiles[i].GetComponent<Collider>().bounds))
                    {
                        canHaveExit = false;
                        thisTile.SetActive(false);
                    }
                }
            }
        }
        roomSpawner.SetActive(true);


    }


    void Update()
    {
        if (exitsNeeded != exitsUsed)
        {
            ExitPoint();
        }

    }

    public void DungeonEnd()
    {
        int alsoRandom = Random.Range(0, points.Count);
        exitPoint = points[alsoRandom];
        points.Remove(exitPoint);
        controller.GetComponent<DungeonController>().EndGame(exitPoint);
    }


    void ExitPoint()
    {
        int alsoRandom = Random.Range(0, points.Count);
        exitPoint = points[alsoRandom];
        points.Remove(exitPoint);
        if (points.Count <= 0)
        {
            canHaveExit = false;
        }
        controller.GetComponent<DungeonController>().MakeATile(exitPoint,this.gameObject);
        exitsUsed++;
    }
}
