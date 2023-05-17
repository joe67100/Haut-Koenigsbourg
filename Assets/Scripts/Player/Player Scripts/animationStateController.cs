using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using VHS;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SideStep();
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SideStep();
        }
    }

    void Move()
    {
        if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)) && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if ((Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            WalkBackwards();
        }
        else
        {
            Idle();
        }
    }

    void WalkBackwards()
    {
        animator.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }
    void Idle()
    {
        animator.SetFloat("Speed", 0.148f, 0.1f, Time.deltaTime);
    }
    void Walk()
    {
        animator.SetFloat("Speed", 0.296f, 0.1f, Time.deltaTime);
    }
    void Run()
    {
        animator.SetFloat("Speed", 0.444f, 0.1f, Time.deltaTime);
    }
    void Jump()
    {
        animator.SetTrigger("Jump");
    }
    void SideStep()
    {
        animator.SetTrigger("SideStep");
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
    }
}