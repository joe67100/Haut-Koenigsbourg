using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jump_Force = 10f;

    private CharacterController character_Controller;
    private Vector3 move_Direction;
    private float gravity = 20f;
    private float vertical_Velocity;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    /**
     * @brief   Update player movement every frame
     * @return  void
    **/
    void Update()
    {
        MoveThePlayer();
    }

    /**
     * @brief   Move the player in a horizontal and vertical axis
     * @return  void
    **/
    void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime; // Time.deltaTime is used to smooth movement

        ApplyGravity();

        character_Controller.Move(move_Direction);
    }

    /**
     * @brief   Apply gravity and test is the player jumps
     * @return  void
    **/
    void ApplyGravity()
    {
        vertical_Velocity -= gravity * Time.deltaTime;

        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;
    }

    /**
     * @brief   Make the player jump if he is on the ground and spacebar is pressed
     * @return  void
    **/
    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_Velocity = jump_Force;
        }
    }
}
