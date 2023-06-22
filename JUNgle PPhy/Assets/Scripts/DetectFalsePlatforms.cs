using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFalsePlatforms : MonoBehaviour
{

    bool hit;

    void Update()
    {
        hit = Physics.Raycast(transform.position, transform.forward, 3, 1 << 8);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red);

        if (hit)
        {
            Debug.Log("AHHh");
        }

        else
        {
            Debug.Log("chill");
        }
    }
}
