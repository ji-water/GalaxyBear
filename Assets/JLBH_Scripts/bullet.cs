using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject explosion;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);

    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);

        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
