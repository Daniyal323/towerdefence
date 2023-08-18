using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 3.5f; 
    private NavMeshAgent enemyAgent; 

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        enemyAgent.speed = enemySpeed; 
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(player.position);
    }
}
