using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject bodyDrop;
    public GameObject spawner;

    public List<Transform> items = new List<Transform>();

    private void Start()
    {
        if(spawner != null)
        {
            spawner.GetComponent<EnemySpawner>().enemyTotal += 1;
        }
    }
    void DropRandomItem()
    {
        RaycastHit itemHit;
        RaycastHit bodyHit;
        Vector3 spawnSpot = transform.position + new Vector3(Random.Range(-1, 1), 30, Random.Range(-1, 1));
        Vector3 spawnRotation = new Vector3(0, Random.Range(-180, 180), 0);
        Vector3 bodySpot = transform.position + new Vector3(Random.Range(-1, 1), 30, Random.Range(-1, 1));
        Vector3 bodyRotation = new Vector3(0, Random.Range(-180, 180), 0);
        Physics.Raycast(spawnSpot, transform.TransformDirection(Vector3.down), out itemHit, 100f, LayerMask.GetMask("Ground"));
        Physics.Raycast(bodySpot, transform.TransformDirection(Vector3.down), out bodyHit, 100f, LayerMask.GetMask("Ground"));
        Instantiate(bodyDrop, bodyHit.point, Quaternion.Euler(bodyRotation));
        Instantiate(items[Random.Range(0, items.Count - 1)], itemHit.point, Quaternion.Euler(spawnRotation));
    }

    public override void Die()
    {
        base.Die();
        DropRandomItem();
        if(spawner != null)
        {
            spawner.GetComponent<EnemySpawner>().Enemykilled();
        }

        //Add ragdoll effect/death animation

        Destroy(gameObject);
    }


}
