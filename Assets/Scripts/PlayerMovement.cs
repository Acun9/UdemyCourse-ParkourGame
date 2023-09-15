using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController characterController;
    public float speed = 10f;

    //Camera Controller
    public float mouseSensitivity = 100f;
    private float xRotation = 0f; //yukari asagi bakarkenki 90 derece siniri

    //Jump and Gravity
    private Vector3 velocity;
    private float gravity = -9.81f;
    private bool isGround;

    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask obstacleLayer;
    public float jumpHeight = 0.5f;
    public float gravityDivide = 1f;
    public float jumpSpeed = 15f;

    private float accelerationTimer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        //Cursor
        Cursor.visible = false;//fare imleci görünmesin
        Cursor.lockState = CursorLockMode.Locked; //fare imlecini ekranin ortasina sabitle
    }
    private void Update()
    {
        //Movement
        Vector3 moveInputs = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        Vector3 moveVelocity = moveInputs * Time.deltaTime * speed;

        characterController.Move(moveVelocity);

        //Camera Controller
        transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Jump and Gravity
        isGround = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, obstacleLayer);

        if (!isGround)
        {
            velocity.y += gravity * Time.deltaTime / gravityDivide;
            accelerationTimer += Time.deltaTime / 3;
            speed = Mathf.Lerp(speed, jumpSpeed, accelerationTimer); // Lerp(10, 20, 0.5) için 15 verir. a ile b arasýndaki c. deðer. Timer sayesinde ivmeli hareket için zamanla artan bir deðer elde ettik.
        }
        else
        {
            velocity.y = -0.05f;
            speed = 10f;
            accelerationTimer = 0;
        }
            
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity / gravityDivide);
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
