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

    private void FixedUpdate()
    {
        if (IsPathComplete())
        {
            StartCoroutine(PatrouilleDelai());
        }
    }

    private IEnumerator PatrouilleDelai()
    {
        int delai = Random.Range(0, 10);

        yield return new WaitForSeconds(delai);

        Patrouille();
    }

    private void Patrouille()
    {
        if (_navMeshAgent.hasPath) FindDestinatiion();

        _navMeshAgent.SetDestination(FindDestinatiion());

        

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

    private bool IsPathComplete()
    {
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            if(_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude == 0.0f)
            {
                return true;
            }
        
        }

        return false;
    }
}
