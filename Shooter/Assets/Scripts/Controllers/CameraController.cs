using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float XAngle;
    public Transform PlayerCamera;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, MouseX, 0);

        XAngle -= MouseY;
        XAngle = Mathf.Clamp(XAngle, -90, 90);
        PlayerCamera.transform.localRotation = Quaternion.Euler(XAngle, 0, 0);// PlayerCamera.localEulerAngles.y


    }
}
