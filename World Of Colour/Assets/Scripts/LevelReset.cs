using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem sys; // hahahahha "sys" like system

    private void Start()
    {
        sys.Stop();    
    }


    public void GameOver()
    {
        player.SetActive(false);
        Invoke("Reload", 2);
        sys.Play();
    }

    private void FixedUpdate()
    {
        sys.transform.position = player.transform.position;
    }

    void Reload()
    {
        SceneManager.LoadScene(1);
    }
}


