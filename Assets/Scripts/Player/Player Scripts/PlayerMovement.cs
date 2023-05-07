using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public float jump_Force = 10f;
    public float speed = 5f;
    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private CharacterController character_Controller;
    private Vector3 move_Direction;
    private float gravity = 20f;
    private float vertical_Velocity;
    [SerializeField] private List<AudioClip> m_FootstepSounds = new List<AudioClip>();
    [SerializeField] private AudioClip m_JumpSound;
    [SerializeField] private AudioClip m_LandSound;
    [SerializeField] private bool m_IsWalking;
    [SerializeField] private float m_StepInterval;
    [SerializeField] [Range(0f, 1f)] private float m_RunstepLengthen;
    private AudioSource m_AudioSource;
    private float m_StepCycle;
    private float m_NextStep;
    private FootstepSwapper swapper;
    private Vector2 m_Input;
    private PlayerMovement playerMovement;
    private Transform look_Root;
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;
    private bool is_Crouching;

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);
        m_AudioSource = GetComponent<AudioSource>();
        m_StepCycle = 0f;
        m_NextStep = m_StepCycle / 2f;
        swapper = GetComponent<FootstepSwapper>();
    }

    /**
     * @brief   Update player movement every frame
     * @return  void
    **/
    void Update()
    {
        MoveThePlayer();
        Sprint();
        Crouch();
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

    private void FixedUpdate()
    {
        ProgressStepCycle(speed);
    }

    private void PlayLandingSound()
    {
        swapper.CheckLayers();

        m_AudioSource.clip = m_LandSound;
        m_AudioSource.PlayOneShot(m_LandSound);
        m_NextStep = m_StepCycle + .5f;
    }

    private void PlayJumpSound()
    {
        swapper.CheckLayers();

        m_AudioSource.clip = m_JumpSound;
        m_AudioSource.Play();
    }

    private void ProgressStepCycle(float speed)
    {
        if (character_Controller.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
        {
            m_StepCycle += (character_Controller.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLengthen))) * Time.fixedDeltaTime;
        }

        if (!(m_StepCycle > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycle + m_StepInterval;

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        swapper.CheckLayers();

        if (!character_Controller.isGrounded)
        {
            return;
        }
        // Pick and play a random footstep sound from the array excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Count);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so isn't picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }

    public void SwapFootsteps(FootstepCollection collection)
    {
        m_FootstepSounds.Clear();
        for (int i = 0; i < collection.footstepSounds.Count; i++)
        {
            m_FootstepSounds.Add(collection.footstepSounds[i]);
        }
        m_JumpSound = collection.jumpSound;
        m_LandSound = collection.landSound;
    }
    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = sprint_Speed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching)
        {
            playerMovement.speed = move_Speed;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // If we are crouching, stand up
            if (is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_Height, 0f);
                playerMovement.speed = move_Speed;

                is_Crouching = false;
            }
            // If we are not crouching, crouch
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_Height, 0f);
                playerMovement.speed = crouch_Speed;

                is_Crouching = true;
            }
        }
    }
}
