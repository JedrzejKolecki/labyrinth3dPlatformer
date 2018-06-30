using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 50.0f;
   
    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;
    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;

    // Use this for initialization
    void Start ()
    {
        camTransform = transform;
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX); //wartosc obecna currentY jest zmieniana miedzy  Y_ANGLE_MIN i Y_ANGLE_MAX

        //przyblizanie/oddalenie widoku
        if (Input.GetAxis("Mouse ScrollWheel") > 0) { distance += 0.2f; }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) { distance -= 0.2f; }


    }
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }

}
