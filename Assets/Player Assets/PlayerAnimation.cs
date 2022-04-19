using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /*---------------------------------------------
     * Code written by Coleman Ostach
     ---------------------------------------------*/

    Animator animator;
    PlayerMovement movement;
    float direction;
    bool isMoving;

    void AnimateMovement()
    {
        isMoving = movement.isMoving;
        direction = movement.keyHorizontalInput;

        animator.SetFloat("Horizontal", direction);

        if (isMoving)
        {
            animator.SetInteger("AnimState", 1);
        }
        else
            animator.SetInteger("AnimState", 0);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        AnimateMovement();
    }
}
