using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
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

    void Start()
    {
        
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (playerInSightRange && playerInAttackRange) Attack();
    }

    public void Attack()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            if(!alreadyAttacked)
            {
                Rigidbody rb = Instantiate(projectile, projectilePos.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
