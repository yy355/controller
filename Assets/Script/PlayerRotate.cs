using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public float lookSpeedX = 2.0f;
    public float lookSpeedY = 2.0f;
    public float upper = 60f;
    public float lower = -60f;
    private float rotationX = 0f;
    private float rotationY = 0f;

    private Transform playerBody;
    private Transform playercamera;


    void Start()
    {
        playerBody = transform;
        playercamera = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        
        rotationY += mouseX * lookSpeedX;
        playerBody.rotation = Quaternion.Euler(0f, rotationY, 0f);  
        rotationX -= mouseY * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, lower, upper);


        playercamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);  
    }
}
