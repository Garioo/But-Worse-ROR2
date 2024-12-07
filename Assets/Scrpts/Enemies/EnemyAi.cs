using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsPlayer;

    // Patroling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    // Animations
    private Animator _animator;

    // Animation Parameters
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    private Transform player;

    private void Awake()
    {
        // Auto-assign player by tag
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found! Ensure the Player GameObject is tagged as 'Player'.");
        }

        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (agent == null)
            Debug.LogError("NavMeshAgent component missing.");
        if (_animator == null)
            Debug.LogError("Animator component missing.");
    }

    private void Update()
    {
        // Check for sight and attack range
        if (player != null)
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            else if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            else if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            SetAnimationState(IsWalking, true);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            SetAnimationState(IsWalking, false);
        }
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            SetAnimationState(IsWalking, true);
        }
    }

    private void AttackPlayer()
    {
        if (player == null) return;

        // Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        SetAnimationState(IsWalking, false);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Debug.Log("Attacking the player!");
            TriggerAnimation(AttackTrigger);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    // Helper method to set an animation bool parameter
    private void SetAnimationState(int parameter, bool state)
    {
        if (_animator != null)
            _animator.SetBool(parameter, state);
    }

    // Helper method to trigger an animation
    private void TriggerAnimation(int parameter)
    {
        if (_animator != null)
            _animator.SetTrigger(parameter);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
