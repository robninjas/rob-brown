using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestruction : MonoBehaviour
{
    GameObject DestructionPoint;

    void Start()
    {
        DestructionPoint = GameObject.Find("obstacleDestPoint");
    }

  
    void Update()
    {
        //if obstacle is behind destruction point, destroy obstacle
        if(transform.position.x < DestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
