using UnityEngine;
using System.Collections;

public class ShotAction : MonoBehaviour {
    
    public GameObject explosion;
    float distance;
    Animator ani;
    public Transform bulletPos;
    //public GameObject SpawnManager;
    //GameObject GameManager;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    // Update is called once per frame
    void Update () {
		transform.position += bulletPos.forward * Time.deltaTime * 5f;
        transform.rotation = bulletPos.rotation;
	
	}


    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(0.5f);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }



    void OnTriggerEnter(Collider other)
    {  

        if (other.CompareTag("enemy") && PlayerShoot.a % 2 == 0)
        {
            //SpawnManager.GetComponent<SpawnManage>().CurrentEnemy--;
            //other.gameObject.GetComponent<MoveEnemy>().SMG.scoreUP();
            //GameManager.GetComponent<ScoreManager>().scoreUP();
           // Instantiate(explosion, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().setDestroy();

            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
        if (other.CompareTag("enemy2") && PlayerShoot.a %2 == 1 )
        {
            //SpawnManager.GetComponent<SpawnManage>().CurrentEnemy--;
            //other.gameObject.GetComponent<MoveEnemy>().SMG.scoreUP();
            //GameManager.GetComponent<ScoreManager>().scoreUP();
           // Instantiate(explosion, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Enemy>().setDestroy();
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }

        if (other.CompareTag("Planet")) {
            this.gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
       // Destroy(this.gameObject);
    }
}
