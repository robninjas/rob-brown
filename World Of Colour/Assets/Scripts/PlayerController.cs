using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    public Color[] playerColor;
    int currentColor;

    public Sprite[] playerSprite;
    int currentSprite;

    int switchTimer;

    HealthDamage HealthDamage;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        HealthDamage = GetComponent<HealthDamage>();

        SwitchSprite();
        SwitchColor();

        switchTimer = -80;
    }
    
    void Update()
    {
        //whenever timer = 100, if not touching obstacle, then change player color
        switchTimer ++;
        if(switchTimer == 40){
            if(HealthDamage.touchingObstacle == false){
                SwitchColor();
                SwitchSprite();
            }
            switchTimer = 0;
        }
    }

    //randomly changes player color and assigns corresponding tag
    void SwitchColor()
    {
        currentColor = Random.Range(0, 3);
            switch(currentColor){
                case 0: 
                    gameObject.tag = "blue";
                    break;
                case 1:
                    gameObject.tag = "pink";
                    break;
                case 2: 
                    gameObject.tag = "yellow";
                    break;
            }
            sr.color = playerColor[currentColor];
    }

    //randomly chooses square or triangle sprite
    void SwitchSprite()
    {
        currentSprite = Random.Range(0, 2);
        sr.sprite = playerSprite[currentSprite];
    }
}
