using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyMovement : MonoBehaviour
{

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnnemyHealth enemyHealth;        // Reference to this enemy's health.
    //NavMeshAgent nav;               // Reference to the nav mesh agent.
    Rigidbody enemyRigidBody;
    public float speed = 3f;

    bool isBlocked = false;
    float timeBlocked = 0f;

    float deviation = 0f;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform; //Pas opti
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnnemyHealth>();
        //nav = GetComponent<NavMeshAgent>();
        enemyRigidBody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            //nav.SetDestination(player.position);

            DeviationManager();

            Turning();
            Move();
        }
        else
        {
            //nav.enabled = false;
        }
    }

    void DeviationManager(){
        if (isBlocked) { timeBlocked += Time.deltaTime; }
        if (timeBlocked >= 1.5f)
        {
            if (deviation >= 45f) { deviation += 5f; }
            else { deviation = 45f; }
            timeBlocked = 0f;
        }
    }

    void Turning(){
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        Quaternion angleRotation = Quaternion.AngleAxis(deviation, transform.up);
        enemyRigidBody.MoveRotation(newRotation * angleRotation);
    }

    void Move(){
        Vector3 movement = transform.forward;
        float speedScaled = speed * transform.lossyScale.x;
        movement *= speedScaled * Time.deltaTime;
        enemyRigidBody.MovePosition(transform.position + movement);
    }

	private void OnTriggerEnter(Collider other)
	{
        print("OnTriggerEnter : " + other.gameObject.name);
        if (other.gameObject == player) { return; }
        print("BLOCKED ");
        isBlocked = true;
	}


	private void OnTriggerExit(Collider other)
	{
        print("OnTriggerExit : " + other.gameObject.name);
        if (other.gameObject == player) { return; }
        print("!!UNBLOCKED");
        timeBlocked = 0;
        deviation = 0f;
        isBlocked = false;
	}
}
