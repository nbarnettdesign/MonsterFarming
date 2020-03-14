using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public List<Transform> items = new List<Transform>();
    public int minDrops;
    public int maxDrops;


    public override void Interact()
    {
        base.Interact();

        int dropAmount = Random.Range(minDrops, maxDrops);
        for (int i = 0; i < dropAmount; i++)
        {
            //THIS BELOW DOESNT WORK
            RaycastHit hit;
            Vector3 spawnSpot = transform.position + new Vector3(Random.Range(-1, 1), 30, Random.Range(-1, 1));
            Vector3 spawnRotation = new Vector3(0, Random.Range(-180,180) , 0);
            Physics.Raycast(spawnSpot, transform.TransformDirection(Vector3.down), out hit, 100f,LayerMask.GetMask("Ground"));
            Instantiate(items[Random.Range(0, items.Count - 1)], hit.point, Quaternion.Euler(spawnRotation));
        }


        //replace with chest opening animation or something
        Destroy(gameObject);

    }

}
