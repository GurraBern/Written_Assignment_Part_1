using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Vector3 startLoc;
    public Vector3 startRot;
    public LineRenderer line;
    public GameObject player;
    public Transform linePointB;
    public Transform linePointA;

    private GameObject zombie;

    public Animator anim;
    public ParticleSystem ps;
    public GameObject bullet;
    public AudioClip audioclip;
    public AudioSource audiosource;

    public float shootDelay;
    private float shootDelayStart;

    public int damage = 5;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        line = GameObject.Find("LineRenderer").gameObject.GetComponent<LineRenderer>();
        linePointB = GameObject.Find("LinePointB").transform;

        anim = player.GetComponent<MovementScript>().anim;
        transform.localPosition = startLoc;
        transform.localEulerAngles = startRot;

        shootDelayStart = shootDelay;
        audiosource.clip = audioclip;
    }
    

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, linePointA.position);
        line.SetPosition(1, linePointB.position);

        float rightTrigger = Input.GetAxis("RightTrigger");


        shootDelay -= Time.deltaTime;

        if (Input.GetMouseButton(0) || rightTrigger > 0)
        {
            anim.SetBool("isShootingAk", true);
            player.GetComponent<MovementScript>().speed = 1.5f;

            if (shootDelay <= 0)
            {
                ShootBullet();

                ps.Play();
                audiosource.Play();


                shootDelay = shootDelayStart;
            }
        }
        else
        {
            anim.SetBool("isShootingAk", false);

        }

    }

    void ShootBullet()
    {
        Instantiate(bullet, ps.transform.position, ps.transform.rotation);

        /*RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(linePointA.position, linePointB.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            zombie = hit.collider.gameObject;
            zombie.GetComponentInChildren<ParticleSystem>().Play();

            zombie.GetComponent<HealthScript>().healthPoints -= damage;

            if(zombie.GetComponent<HealthScript>().healthPoints <= 0)
            {
                Destroy(zombie);
            }

        }
        */


    }
}
