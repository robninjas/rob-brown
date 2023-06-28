using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriggerenter : MonoBehaviour
{
    public GameObject wall;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            Destroy(wall);
        }
    }
}
