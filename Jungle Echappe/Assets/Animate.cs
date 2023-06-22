using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;

    Jump jump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump.isGrounded)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackwards", false);
        }

        if (jump.isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isWalkingBackwards", false);

            if (Input.GetAxisRaw("Vertical") == 1)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalkingBackwards", false);
            }

            if (Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetBool("isWalkingBackwards", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", false);
            }
        }
    }
}
