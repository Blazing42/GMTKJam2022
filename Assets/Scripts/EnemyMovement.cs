using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    NavMeshAgent navAgent;
    GameObject player;
    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;


    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange;
    public float attackRange;

    public bool playerInSight;
    public bool playerInAttackRange;
    

    public EnemySpawner spawner;
    public GameObject deathParticles;
    public AudioClip pop;

    public void Awake()
    {
        player = GameObject.Find("player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSight && !playerInAttackRange)
        {
            Patrolling();
        }
        if(!playerInAttackRange && playerInSight)
        {
            Chasing();
        }
        if(playerInAttackRange)
        {
            Attacking();
        }
    }

    void Patrolling()
    {
        if (!walkPointSet) SetWalkPOint();
        else
        {
            navAgent.SetDestination(walkPoint);
        }
            

        Vector3 distanceToWalkpoint = transform.position - walkPoint;
        if (distanceToWalkpoint.magnitude < 2f)
        {
            walkPointSet = false;
        }
            
    }

    void SetWalkPOint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if(Physics.Raycast(walkPoint, -Vector3.up, 2f,whatIsGround))
        {
                walkPointSet = true;
        }
    }

    void Chasing()
    {
        navAgent.SetDestination(player.transform.position);
    }

    void Attacking()
    {
        navAgent.SetDestination(transform.position);
        if (!alreadyAttacked)
        {
            if(Vector3.Distance(player.transform.position, this.transform.position) < 2f)
            {
                player.GetComponent<PlayerMovement>().loseLife();
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void GetHit()
    {
        spawner.RemoveEnemy(this.gameObject);
        UIController.UIControllerInstance.TickUpKillcount();
        AudioSystem.AudioSystemInstance.PlayAudioCLip(pop, 0.4f);
        Instantiate(deathParticles, this.transform.position, Quaternion.identity);
        Invoke(nameof(Destroy), 0.4f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
