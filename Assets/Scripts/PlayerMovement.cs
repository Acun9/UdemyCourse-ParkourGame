using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    private CharacterController characterController;
    public float speed = 1f;

    //Camera Controller
    public float mouseSensitivity = 100f;
    private float xRotation = 0f; //yukari asagi bakarkenki 90 derece siniri

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
    }
}
