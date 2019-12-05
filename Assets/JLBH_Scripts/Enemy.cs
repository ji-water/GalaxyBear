using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;
    private Transform planet;
    public float movePower = 1f;
    int movementFlag = 0;

    float MinDist = 4f;
    bool removeFlag = false;

    Vector3 axis;
    Vector3 to;
    Vector3 forwardDir;
 
    Vector3 position;
    private HealthManager hm;

    void Start()
    {
        //position = (12) * Random.onUnitSphere;
        player = GameObject.Find("player").GetComponent<Transform>();
        planet = GameObject.Find("Desert_Planet").GetComponent<Transform>();
        hm = GameObject.Find("GameManager").GetComponent<HealthManager>();
        StartCoroutine("ChangeMovement");
        //nav = GetComponent<NavMeshAgent>();
    }

    //void Update()
    //{
    //    float distance = Vector3.Distance(transform.position, player.position);
    //    transform.LookAt(player);
    //    if (distance >= MinDist)
    //    {
    //        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    //    }
        
    //}

    void FixedUpdate()
    {
        if (!removeFlag)
           Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= 1f)
        {
            hm.Hit();
            Destroy(this.gameObject);
            return;
        }

        if (distance >= MinDist)
        {
            to = transform.position - planet.position;
            axis = Vector3.Cross(to, player.position - planet.position);
            forwardDir = Vector3.Cross(axis, to);
            transform.LookAt(transform.position + forwardDir, to);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, player.position - transform.position, MoveSpeed);
            //transform.LookAt(player);
            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        
        if (movementFlag==1)
        {
            moveVelocity = Vector3.left;
            
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementFlag == 2)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 3)
        {
            moveVelocity = Vector3.up;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movementFlag == 4)
        {
            moveVelocity = Vector3.forward;
        }

        else if(movementFlag == 5)
        {
            moveVelocity = Vector3.one;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }


    IEnumerator ChangeMovement()
    {
        while(true)
        {
            movementFlag = Random.Range(0, 6);
            float time = Random.Range(2f, 5f);
            yield return new WaitForSeconds(time);
        }
    }

    public void setDestroy()
    {
        if (!removeFlag)
        {
            removeFlag = true;
            Animator ani = GetComponent<Animator>();
            ani.SetInteger("animation", 6);
            Destroy(gameObject, 2f);
        }
    }

}
