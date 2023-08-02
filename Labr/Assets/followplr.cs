using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followplr : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent blah;
    public GameObject plr;

    // Start is called before the first frame update
    void Start()
    {
        var x = plr.GetComponent<NavMeshAgent>();
        blah = GetComponent<NavMeshAgent>();
        blah.acceleration = x.acceleration;
        blah.speed = x.speed;
        blah.angularSpeed = x.angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        blah.destination = target.position;

    }
}
