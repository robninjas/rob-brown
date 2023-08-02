using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public Transform goal;
    public Transform goal2;
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.hasPath)
        {
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin")) {
            Destroy(other);
            other.GetComponent<MeshRenderer>().enabled = false;
            agent.destination = goal2.position;
        }
    }
}
