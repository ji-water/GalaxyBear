using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    //public Transform mainCam;
    public float gravity = -9.8f;
    //public int rotateSpeed = 10;
    //Vector3 thisPos;

    /*
    private void Start()
    {
        thisPos = transform.position;
    }

    
    private void Update()
    {
        float inputY = - Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1"))
            inputY = -1;
        if (inputY != 0 || inputX != 0)
        {
            Vector3 moveDir = mainCam.right * inputY + mainCam.forward * inputX;
            transform.RotateAround(thisPos, moveDir, Time.deltaTime * rotateSpeed);
        }
    }
    */

    public void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        // Apply downwards gravity to body
        body.AddForce(gravityUp * gravity);
        // Allign bodies up axis with the centre of planet
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }
}
