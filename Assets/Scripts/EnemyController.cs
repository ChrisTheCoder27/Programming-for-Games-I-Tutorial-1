using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public LayerMask groundLayer, playerLayer;

    Rigidbody enemy;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public bool playerInSightRange, playerInAttackRange;
    public float sightRange, attackRange;

    public GameObject projectile;
    public GameObject projectilePos;
    Rigidbody bulletRb;
    public float timeBetweenAttacks;

    bool alreadyAttacked;

    private EAIState aiState = EAIState.Idle;

    private enum EAIState
    {
        Idle = 1,
        Patrol = 2,
        Move = 4
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (playerInSightRange && playerInAttackRange) Attack();

        if (!playerInSightRange && !playerInAttackRange) Patrol();

        if (playerInSightRange && !playerInAttackRange) Chase();
    }

    public void Attack()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void Patrol()

    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {

            agent.SetDestination(walkPoint);
        }
        Vector3 distanceWalkPoint = transform.position - walkPoint;

        if (distanceWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 1f, groundLayer))
        {
            walkPointSet = true;
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void MoveToTarget(Vector3 hitObjectRes)
    {
        aiState = EAIState.Move;
        agent.SetDestination(hitObjectRes);
        agent.isStopped = false;
    }
}
