using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{

    Transform target;
    public GameObject player;
    //public GameObject slime;
    //public GameObject skeleton;
    //public GameObject human;
    bool movingToAttackRange = false;


    float distance;

    NavMeshAgent agent;

    private float FaceRotateSpeed = 5f;
       
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        if (target !=null && movingToAttackRange)
        {
            distance = Vector3.Distance(player.transform.position, target.transform.position);
            if (distance <= agent.stoppingDistance)
            {
                target.GetComponent<Enemy>().Interact();
                target.GetComponent<EnemyController>().BeenHit();
                //slime.GetComponent<SlimeSkills>().SkillsUsed();
                //will need one for all forms
                movingToAttackRange = false;
            }
        }

    }

    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = (newTarget.radius * .8f);
        agent.updateRotation = false;
        Debug.Log("target: " + newTarget.name);
        target = newTarget.interactionTransform;
    }

    /*public void AttackTarget(Interactable newTarget, float attackRange, float baseAttackRange)
    {
        agent.stoppingDistance = (newTarget.radius * .8f) + attackRange;
        agent.updateRotation = false;
        Debug.Log("target: " + newTarget.name);
        distance = Vector3.Distance(player.transform.position, newTarget.transform.position);
        target = newTarget.interactionTransform;
        movingToAttackRange = true;

    }*/

   /* public void SkillUsed()
    {
        agent.SetDestination(player.transform.position);
    }*/

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = .2f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * FaceRotateSpeed);
    }
}
