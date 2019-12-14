using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float jumpForce;
    [SerializeField]
    bool grounded = true;

    public HealthManager HM;
    public Transform mainCam, arrow;
    Rigidbody rigid;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    int groundedMask;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = 80;
        rigid = GetComponent<Rigidbody>();
        groundedMask = 1 << LayerMask.NameToLayer("Ground");
        //rigid.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rigid.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("thorn"))
        {
            HM.Hit();
        }
        else if (other.CompareTag("explosion"))
        {
            HM.Hit();
        }

       /* if (other.CompareTag("Planet"))
        {
            grounded = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {

        //Jump
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) //SPACE
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }
#else
        if (Input.GetKeyDown(KeyCode.JoystickButton3)) //Y
        {
            if (grounded)
            {
                rigid.AddForce(transform.up * jumpForce);
            }
        }
#endif

        // Grounded check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.5f, groundedMask))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }



    }

   
}
