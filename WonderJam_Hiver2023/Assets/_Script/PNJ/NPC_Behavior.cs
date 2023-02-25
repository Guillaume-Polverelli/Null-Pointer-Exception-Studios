using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Behavior : MonoBehaviour
{

    public LayerMask groundLayer, playerLayer;

    public Vector3 destination;
    bool bHasDestination;
    public float destinationDistance;

    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Patrouille();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Patrouille()
    {
        if (!bHasDestination) FindDestinatiion();
        
    }

    private Vector3 FindDestinatiion()
    {
        Vector3 randomDestination = Random.insideUnitSphere * destinationDistance;
        randomDestination += transform.position;
        NavMeshHit hit;
        Vector3 finalDestination = Vector3.zero;

        if (NavMesh.SamplePosition(randomDestination, out hit, destinationDistance, 1))
        {
            finalDestination = hit.position;
        }
        return finalDestination;
    }

}
