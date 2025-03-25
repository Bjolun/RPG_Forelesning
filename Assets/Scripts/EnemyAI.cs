using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Referanse til en Coin prefab
    [SerializeField] private GameObject coinPrefab;

    // Referanse til modellen med Animator
    [SerializeField] private Animator animator;

    // Referanse til spilleren
    private GameObject player;

    // Referanse til NavMesh Agent komponenten v�r.
    private NavMeshAgent agent;

    // Referanse til coinHolder
    private GameObject coinHolder;

    // Oppsett av states
    private enum States
    {
        Attack,
        Chase,
        Dead,
    }

    // states variabel
    private States states;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        states = States.Chase;
    }

    private void Update()
    {
        switch (states)
        {
            case States.Attack:
                Attack();
                break;
            case States.Chase:
                ChaseTarget();
                break;
            case States.Dead:
                break;
        }

        Debug.Log(states);
    }

    // Metode som kalles p� i Chase state
    private void ChaseTarget()
    {
        // Sette hastigheten til fienden
        agent.speed = 3;

        // Oppdatere destinasjon til � v�re lik spilleren sin posisjon
        agent.SetDestination(player.transform.position);

        // Spille av en l�pe animasjon
        animator.SetBool("isChasing", true);

        // Hvis fienden kommer n�re nok til spilleren, s�...
        if(!agent.pathPending && agent.remainingDistance < 2)
        {
            // Skru av l�peanimasjon
            animator.SetBool("isChasing", false);
            // Bytte til Attack state.
            states = States.Attack;
        }
    }

    // Metode for Attack State 
    private void Attack()
    {
        // Skru fart ned til 0
        agent.speed = 0;

        // Oppdatere destinasjon til � v�re lik spilleren sin posisjon.
        agent.SetDestination(player.transform.position);

        // Spille av animasjon for angrep
        animator.SetBool("isAttacking", true);

        // Hvis spilleren g�r for langt unna, g� tilbake til chasing...
        if(!agent.pathPending && agent.remainingDistance > 2)
        {
            // Skru av animasjon for angrep
            animator.SetBool("isAttacking", false);
            // Bytte til Chase state.
            states = States.Chase;
        }

    }
}
