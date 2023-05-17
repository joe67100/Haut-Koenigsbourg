using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMenu : MonoBehaviour
{
    private Animator cameraAnimator;
    [SerializeField] private int timeBeforePlayingAnimation;

    private void Start()
    {
        cameraAnimator = GetComponent<Animator>();
        cameraAnimator.enabled = false;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad >= timeBeforePlayingAnimation)
        {
            cameraAnimator.enabled = true;
        }
    }
}
