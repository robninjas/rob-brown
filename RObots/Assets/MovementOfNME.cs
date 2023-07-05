using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfNME : MonoBehaviour
{
    public float yforce;
    public float xforce;
    public float xdir;

    private Rigidbody2D enemyRigidBody;
    public Rigidbody2D playerRigidBody;

    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();

        xforce *= enemyRigidBody.mass;
        yforce *= enemyRigidBody.mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy")
        {
            Vector2 jumpForce = new Vector2(xforce * xdir, yforce);
            enemyRigidBody.AddForce(jumpForce);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            var enemy = collision.collider.gameObject;

            if (enemy.transform.position.x > transform.position.x)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new(500 * 1000, 0));
            }

            if (enemy.transform.position.x < transform.position.x)
            {
                enemy.GetComponent<Rigidbody2D>().AddForce(new(-500 * 1000, 0));
            }
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x <= -8)
        {
            xdir = 1;
            enemyRigidBody.AddForce(Vector2.right * xforce);
        }

        if (transform.position.y >= 5)
        {
            enemyRigidBody.AddForce(Vector2.down * yforce);
        }

        if (transform.position.x >= 8)
        {
            xdir = -1;
            enemyRigidBody.AddForce(Vector2.left * xforce);
        }
    }

}
