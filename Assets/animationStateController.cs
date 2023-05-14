using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isJumpingHash = Animator.StringToHash("isJumping");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool jumpPressed = Input.GetKey(KeyCode.Space);

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
    }
}