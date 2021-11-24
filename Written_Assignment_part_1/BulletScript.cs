using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletDamage = 5;
    public float bulletSpeed = 2f;
    //public float knockback;

    public ParticleSystem psSparks;
    private void Start()
    {
        //knockback = 150;
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zombie")
        {
            other.gameObject.GetComponent<HealthScript>().healthPoints -= bulletDamage;
            other.gameObject.GetComponentInChildren<ParticleSystem>().Play();

            //Vector3 direction = other.transform.position - transform.position;
            //direction.y = 0;
            //other.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * knockback,ForceMode.Force);


            if (other.GetComponent<HealthScript>().healthPoints <= 0)
            {
                other.GetComponentInChildren<Animator>().SetBool("isDead", true);
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                other.GetComponent<DestroyTimer>().enabled = true;
            }
        }
        else if (other.gameObject.tag == "outofbounds")
            Instantiate(psSparks, transform.position, transform.rotation);
        psSparks.GetComponent<SparkScript>().lookingDir = transform.position;

        Destroy(gameObject);
    }
}