using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 10f;

    int speedTimer;

    bool canMoveUp;
    bool canMoveDown;
    Vector3 moveFactor = new Vector3(0, 3.3f, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if timer = 1000, increase speed by 1
        speedTimer ++;
        if(speedTimer == 1000){
            Debug.Log("Speed increase");
            speed += 1f;
            speedTimer = 0;
        }
        
        //can't move off screen
        if(rb.position.y < 3f){
           canMoveUp = true;
        } else{
           canMoveUp = false;
        } 
        if(rb.position.y > -3f){
           canMoveDown = true;
        } else{
           canMoveDown = false;
        }

        //translate up and down movement
        if(canMoveUp && Input.GetKeyDown(KeyCode.UpArrow) || canMoveUp && Input.GetKeyDown(KeyCode.W)){
            transform.Translate(moveFactor);
        } 
        if(canMoveDown && Input.GetKeyDown(KeyCode.DownArrow) || canMoveDown && Input.GetKeyDown(KeyCode.S)){
            transform.Translate(moveFactor * -1);
        }
    }

    void FixedUpdate()
    {
        //constantly move forward according to forwardSpeed
        transform.Translate(Vector3.right * speed * Time.deltaTime);     
    }
}
