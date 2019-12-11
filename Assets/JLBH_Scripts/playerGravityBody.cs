using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGravityBody : MonoBehaviour
{
    public GravityAttractor playerPlanet;
    Rigidbody rigidbody;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        if (rigidbody != null && playerPlanet != null)
            playerPlanet.Attract(rigidbody);
    }
}
