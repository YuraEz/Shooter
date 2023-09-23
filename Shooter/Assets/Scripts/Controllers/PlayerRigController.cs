using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRigController : MonoBehaviour
{
    public Transform HeadAim;
    public Transform BodyAim;
    public Transform PlayerCamera;
    public LayerMask GroundObstecalMask;



    public void Update()
    {
        Ray CameraRay = new Ray(PlayerCamera.position, PlayerCamera.forward);
        RaycastHit CameraRayHit;

        if (Physics.Raycast(CameraRay, out CameraRayHit, 5, GroundObstecalMask))
        {
            HeadAim.position = CameraRayHit.point;
            BodyAim.position = CameraRayHit.point;
        }
        else
        {
            HeadAim.position = CameraRay.GetPoint(5);
            BodyAim.position = CameraRay.GetPoint(5);
        }
    }




}
