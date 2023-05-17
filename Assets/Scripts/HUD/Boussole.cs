using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boussole : MonoBehaviour
{
    public Transform playerCamera;
    public float rotationSpeed = 5f; // Adjust this value to control the rotation speed

    private Quaternion initialRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Calculate the player's camera rotation around the Y-axis (horizontal rotation)
        float playerCameraRotation = playerCamera.rotation.eulerAngles.y+180;

        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, playerCameraRotation);

        // Smoothly interpolate between the current rotation and the target rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}