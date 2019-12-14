using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    public Transform cam;
    Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        rotation = transform.localRotation;
        rotation.y = Quaternion.LookRotation(transform.position - cam.position).y;
        transform.localRotation = rotation;
    }
}
