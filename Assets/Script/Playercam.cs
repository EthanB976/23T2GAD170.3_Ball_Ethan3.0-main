using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercam : MonoBehaviour
{

    //Grab the X and Y axsis 
    public float sensX;
    public float sensY;

    //Player orientation
    public Transform orientation;

    //rotation of the camera
    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        //locks cursor to the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //turns cursor invisable
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //handles unity rotation and inout
        yRotation += mouseX;
        xRotation -= mouseY;

        //Locks rotation at 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
