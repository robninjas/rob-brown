using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDamage : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject player;
    int score;
    public Text scoreText;

    public bool touchingObstacle;

    PlayerController PlayerController;
    LevelReset LevelReset;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        PlayerController = GetComponent<PlayerController>();
        LevelReset = GetComponent<LevelReset>();

        score = 0;

        touchingObstacle = false;
    }
    void Update()
    {
        scoreText.text = score.ToString();
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        touchingObstacle = true;

        //if square player
        if(sr.sprite == PlayerController.playerSprite[0]){
            if(!other.CompareTag("obstacle")){
                //if hit wrong color obstacle, game over
                if(other.tag != gameObject.tag){
                    LevelReset.GameOver();
                    Debug.Log("GameOver");
                }
                //if hit right color obstacle, increase score
                if(other.tag == gameObject.tag){
                    score++;
                }
            }
        }

        //if triangle player
        if(sr.sprite == PlayerController.playerSprite[1]){
            if(!other.CompareTag("obstacle")){
                //if hit platform obstacle, GO
                if(other.name == "platform(Clone)"){
                    LevelReset.GameOver();
                    Debug.Log("GameOver");
                }
                //if hit spikes obstacle, increase score
                if(other.name == "spikes(Clone)"){
                    score++;
                }
            }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        touchingObstacle = false;
    }
}

