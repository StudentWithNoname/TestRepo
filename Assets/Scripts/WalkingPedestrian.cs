using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingPedestrian : MonoBehaviour
{
    public float moveRadius = 10f;
    public float interval = 4f; // 
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = interval;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            SetNewRandomDestination();
            timer = 0; 
        }
    }

    void SetNewRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius + transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, -1))
        {
            agent.SetDestination(hit.position);
        }
    }
}