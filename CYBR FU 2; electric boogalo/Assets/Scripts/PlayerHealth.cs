using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentPlayerHealth;
    public int InitialPlayerHealth = 1337;
    public int enemyDamage = 2;

    private Animator PlayerAnimator;
    public Text MaxHealth;

    public PlayerExplosionParticles particles;
   
    void Start()
    {
        currentPlayerHealth = InitialPlayerHealth;
        enemyDamage = 8;

        // print(InitialPlayerHealth.ToString());

        MaxHealth.text = "/" + InitialPlayerHealth.ToString();

        PlayerAnimator = GetComponent<Animator>();
        particles = GetComponent<PlayerExplosionParticles>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitCollider"))
        {
            HurtPlayer();
        }
    }
    public void HurtPlayer()
    {
        currentPlayerHealth -= enemyDamage;
        PlayerAnimator.SetTrigger("Hit");

        if (currentPlayerHealth <= 0)
        {
            gameObject.SetActive(false);
            particles.Explode();
            Invoke("ReloadScene", 5);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("CyberFu");
    }

}
