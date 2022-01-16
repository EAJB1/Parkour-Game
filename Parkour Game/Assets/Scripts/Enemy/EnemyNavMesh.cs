using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] private Transform playerTransform, enemyTransform;
    [SerializeField] private float detectionRange = 10.0f;
    private NavMeshAgent navMeshAgent;
    private Vector3 curPos, playerPos;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Assign game object position to Vector3
        curPos = enemyTransform.position;
        playerPos = playerTransform.position;

        // If player is within the detection range
        if (Vector3.Distance(curPos, playerPos) < detectionRange)
        {
            // Move player to target (player)
            navMeshAgent.destination = playerTransform.position;
        }
    }
}
