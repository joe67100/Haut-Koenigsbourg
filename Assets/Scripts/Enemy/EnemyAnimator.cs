using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isAttackingHash;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    public void Walk(bool isWalking)
    {
        animator.SetBool(isWalkingHash, isWalking);
    }

    public void Run(bool isRunning)
    {
        animator.SetBool(isRunningHash, isRunning);
    }

    public void Attack()
    {
        animator.SetTrigger(isAttackingHash);
    }
}