using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tonmou_Behavior : MonoBehaviour
{
    public Transform Player;
    public LayerMask groundLayer, playerLayer;

    public Vector3 destination;
    bool bHasDestination;
    public float destinationDistance;

    private NavMeshAgent _navMeshAgent;

    private bool bHasAttacked;

    private Animator _animator;


    [SerializeField] private float damages;
    [SerializeField] private float attackCooldown = 1.0f;
    [SerializeField] private float sightRange = 30.0f;
    [SerializeField] private float attackRange = 20.0f;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private bool bPlayerInSight;
    private bool bPlayerInAttackRange;

    private bool bIsDead;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        Patrouille();
    }

    // Update is called once per frame
    void Update()
    {
        if(_navMeshAgent.velocity.magnitude == 0)
        {
            _animator.SetBool("Walk Forward", false);
            _animator.SetBool("Run Forward", false);
        }
    }

    private void FixedUpdate()
    {
        if (bIsDead) return;

        if (IsPathComplete() && !bPlayerInSight && !bPlayerInAttackRange)
        {
            StartCoroutine(PatrouilleDelai());
        }

        bPlayerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        bPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (bPlayerInSight && !bPlayerInAttackRange) ChasePlayer();
        if (bPlayerInAttackRange && bPlayerInSight) AttackPlayer();
    }

    private IEnumerator PatrouilleDelai()
    {
        int delai = Random.Range(0, 10);

        yield return new WaitForSeconds(delai);

        Patrouille();
    }

    private void Patrouille()
    {

        _navMeshAgent.speed = walkSpeed;
        _animator.SetBool("Walk Forward", true);
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

    public void ChangeIsStopped(bool bIsStopped)
    {
        _navMeshAgent.isStopped = bIsStopped;
    }

    public void ChasePlayer()
    {
        _animator.SetBool("Run Forward", true);
        _navMeshAgent.speed = runSpeed;
        _navMeshAgent.SetDestination(Player.position);
    }

    public void AttackPlayer()
    {
        _navMeshAgent.SetDestination(transform.position);
        transform.LookAt(Player);

        if (!bHasAttacked)
        {
            _animator.SetTrigger("Stab Attack");
            bHasAttacked = true;
            Invoke(nameof(ResetAttack), attackCooldown);
            Player.GetComponent<Character>().TakeDamage(damages);
        }
    }

    public void ResetAttack()
    {
        bHasAttacked = false;
    }

    public void Die()
    {
        if (bIsDead) return;
        _animator.SetTrigger("Die");
        bIsDead = true;
    }
}
