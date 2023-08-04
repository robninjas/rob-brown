using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject gem;
    public GameObject background;
    public string teleportDestination;


    private void OnTriggerEnter(Collider other)
    {
        if (!gem.activeInHierarchy)
        {
            background.GetComponent<GameManager>().TeleportOpen(teleportDestination);
        }

    }
}
