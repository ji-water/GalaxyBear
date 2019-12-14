using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform planet;
    public float movePower = 1f;
    public GameObject exp;
    int movementFlag = 0;

    float MinDist = 4f;
    bool removeFlag = false;

    Vector3 axis;
    Vector3 to;
    Vector3 forwardDir;
 
    Vector3 position;
    public HealthManager hm;

    public GameObject SpawnManager;
    public ScoreManager SM;
    Animator ani;

    void Awake()
    {
        //position = (12) * Random.onUnitSphere;
        //StartCoroutine("ChangeMovement");
        //nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //effect vol
        float vol = PlayerPrefs.GetInt("EFFvol", 5) * 0.2f;
        GetComponent<AudioSource>().volume = vol;
    }

    private void OnEnable()
    {
        ani.SetInteger("animation", 15);
        removeFlag = false;
        exp.SetActive(false);
        StartCoroutine("ChangeMovement");
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

    void Update()
    {
        if (!removeFlag)
           Move();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        /*
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance <= 1f)
        {
            hm.Hit();
            offenmemy();
            //Destroy(this.gameObject);
            return;
        }*/

        //if (distance >= MinDist)
        //{
            to = transform.position;
            axis = Vector3.Cross(to, player.position);
            forwardDir = Vector3.Cross(axis, to);
            transform.LookAt(transform.position + forwardDir, to);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, player.position - transform.position, MoveSpeed);
            //transform.LookAt(player);
            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
        
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
            int time = Random.Range(2, 5);
            yield return new WaitForSeconds(time);
        }
    }

    public void setDestroy()
    {
        if (!removeFlag)
        {
            removeFlag = true;
            exp.SetActive(true);
            Animator ani = GetComponent<Animator>();
            ani.SetInteger("animation", 6);

            SM.scoreUP();
            
            Invoke("offenmemy", 2f);
        }
    }

    public void offenmemy() {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("playerHitZone"))
        {
            hm.Hit();
            offenmemy();
        }
    }
}
