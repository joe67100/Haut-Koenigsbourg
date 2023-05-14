using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isWalkingBackwardHash;
    int isWalkingLeftHash;
    int isWalkingRightHash;
    int isRunningHash;
    int isJumpingHash;
    int isAttacking1Hash;
    int isAttacking2Hash;
    int isAttacking3Hash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackwardHash = Animator.StringToHash("isWalkingBackward");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
        isAttacking1Hash = Animator.StringToHash("isAttacking1");
        isAttacking2Hash = Animator.StringToHash("isAttacking2");
        isAttacking3Hash = Animator.StringToHash("isAttacking3");
    }

    public void StopAttacking()
    {
        animator.SetBool(isAttacking1Hash, false);
        animator.SetBool(isAttacking2Hash, false);
        animator.SetBool(isAttacking3Hash, false);
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isWalkingBackward = animator.GetBool(isWalkingBackwardHash);
        bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
        bool isWalkingRight = animator.GetBool(isWalkingRightHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isAttacking = animator.GetBool(isAttacking1Hash) || animator.GetBool(isAttacking2Hash) || animator.GetBool(isAttacking3Hash) ? true : false;
        bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
        bool backwardPressed = Input.GetKey(KeyCode.DownArrow);
        bool leftPressed = Input.GetKey(KeyCode.LeftArrow);
        bool rightPressed = Input.GetKey(KeyCode.RightArrow);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        bool attackPressed = Input.GetKey(KeyCode.A);

        // Player is walking
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        // Player is stop walking
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        // Player is walking backward
        if (!isWalkingBackward && backwardPressed)
        {
            animator.SetBool(isWalkingBackwardHash, true);
        }
        // Player is stop walking backward
        if (isWalkingBackward && !backwardPressed)
        {
            animator.SetBool(isWalkingBackwardHash, false);
        }
        // Player is walking left
        if (!isWalkingLeft && leftPressed)
        {
            animator.SetBool(isWalkingLeftHash, true);
        }
        // Player is stop walking left
        if (isWalkingLeft && !leftPressed)
        {
            animator.SetBool(isWalkingLeftHash, false);
        }
        // Player is walking right
        if (!isWalkingRight && rightPressed)
        {
            animator.SetBool(isWalkingRightHash, true);
        }
        // Player is stop walking right
        if (isWalkingRight && !rightPressed)
        {
            animator.SetBool(isWalkingRightHash, false);
        }
        // Player is running
        if (!isRunning && forwardPressed && runPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        // Player is stop running
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
        // Player is jumping
        if (!isJumping && jumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        // Player is stop jumping
        if (isJumping && !jumpPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }
        // Player is attacking
        if (!isAttacking && attackPressed)
        {
            int randomNumber = UnityEngine.Random.Range(1, 4);

            switch (randomNumber)
            {
                case 1:
                    animator.SetBool(isAttacking1Hash, true);
                    break;
                case 2:
                    animator.SetBool(isAttacking2Hash, true);
                    break;
                case 3:
                    animator.SetBool(isAttacking3Hash, true);
                    break;
                default:
                    break;

            }
        }
    }
}