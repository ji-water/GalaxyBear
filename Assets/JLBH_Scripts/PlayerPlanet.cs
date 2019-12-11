using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanet : MonoBehaviour
{
    public Transform mainCam;
    public int rotateSpeed = 10;
    Vector3 thisPos;

    private void Start()
    {
        thisPos = transform.position;
    }

    private void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = -Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1"))
            inputY = 1;
        if (inputY != 0 || inputX != 0)
        {
            Vector3 moveDir = mainCam.right * inputY + mainCam.forward * inputX;
            transform.RotateAround(thisPos, moveDir, Time.deltaTime * rotateSpeed);
        }
    }
}
