using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;



    //patroling phase

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    private NavMeshHit hit;
    private bool blocked = false;


    //attacking phase

    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    //States

    public float sightRange, attackRange;
    public bool playerIsInSight, playerIsInAttackRange;


    void awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }


    // Update is called once per frame
    void Update()
    {
        playerIsInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);
        playerIsInSight = Physics.CheckSphere(transform.position, sightRange, playerMask);

        if (!playerIsInAttackRange && !playerIsInSight) patroling();
        if (!playerIsInAttackRange && playerIsInSight) chasePlayer();
        if (playerIsInAttackRange && playerIsInSight) attackPlayer();

    }



    private void patroling()
    {
       

        if (!walkPointSet) searchWalkPointRange();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void searchWalkPointRange()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        blocked = NavMesh.Raycast(transform.position, walkPoint, out hit, NavMesh.AllAreas);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask) && !blocked)
        {
            walkPointSet = true;
        }
    }





    private void chasePlayer()
    {

        
        agent.SetDestination(player.position);

    }

    private void attackPlayer()
    {
        //here if want to attack
    }


}
