using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform Target;
    // Start is called before the first frame update    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.isPlaying)
        {
            navMeshAgent.SetDestination(Target.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }
    }
}
