using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    bool isAttacking;
    public bool isWanderer;
    public float wanderRadius;
    public float wanderTimer = 5f;
    public float timer;
    public float walkSpeed;
    public float runSpeed;
    public Vector3 newPos;

    Transform target;

    NavMeshAgent agent;

    CharacterCombat combat;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        isAttacking = false;
        timer = 0;
        agent.speed = walkSpeed;
    }

    // Update is called once per frame
    public void BeenHit()
    {
        lookRadius = (Vector3.Distance(target.position, transform.position)) + 1f;
    }

    void Update()
    {
        if (isWanderer)
        {
            timer += Time.deltaTime;
        }
        float distance = Vector3.Distance(target.position, transform.position);

        if (!isAttacking && isWanderer)
        {
            if (timer >= wanderTimer)
            {
                WanderAround(wanderRadius);
                timer = 0;
            }
        }
        if (distance <= lookRadius)
        {
            isAttacking = true;
            agent.speed = runSpeed;
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    combat.Attack(targetStats);
                }

                FaceTarget();
            }
        }

    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void WanderAround(float radius)
    {
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        newPos = RandomNavSphere(transform.position, radius, 9);
        agent.SetDestination(newPos);

    }
}
