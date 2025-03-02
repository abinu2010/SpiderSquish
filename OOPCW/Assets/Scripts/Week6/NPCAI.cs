using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{
    public enum AIState
    {
        Idle,
        Attacking
    }

    public AIState currentState = AIState.Idle;
    public float attackRange = 5f;
    public NPCWeapon npcWeapon;

    private GameObject player;
    private NPCController npcController;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        npcController = GetComponent<NPCController>();
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            currentState = AIState.Attacking;
        }
        else
        {
            currentState = AIState.Idle; 
        }
    }

    private void FixedUpdate()
    {
        if (currentState == AIState.Attacking)
        {
            MoveTowardsPlayer();
        }
    }

    public bool IsPlayerInRange()
    {
        if (player == null)
        {
            return false;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer <= attackRange;
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            direction.z = 0f;
            npcController.Move(direction);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}