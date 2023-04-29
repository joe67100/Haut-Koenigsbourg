using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script permettant de détecter les inputs du joueur

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;

    [SerializeField]
    private float mouseSensitivityX = 10f;
    [SerializeField]
    private float mouseSensitivityY = 10f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        // Calcul du vecteur de déplacement
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;
        // Application du déplacement
        motor.Move(velocity);

        // Calcul de la rotation du joueur
        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f) * mouseSensitivityX;
        // Application de la rotation
        motor.Rotate(rotation);

        // Calcul de la rotation de la caméra
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivityY;
        // Application de la rotation de la caméra
        motor.RotateCamera(cameraRotation);
    }
}
