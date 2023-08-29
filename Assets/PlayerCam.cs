using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;
    public Transform orientationTransform;

    float xRotation;
    float yRotation;


    
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xSensitivity = 400;
        ySensitivity = 400;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * xSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * ySensitivity * Time.deltaTime ;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //rotate the camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //rotate the player
        orientationTransform.rotation = Quaternion.Euler(0, yRotation, 0);

        
    }
}
