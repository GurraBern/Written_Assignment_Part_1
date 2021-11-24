using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public GameObject playerBody;
    public Transform aimingBody;
    public ParticleSystem sprintPS;
    public GameObject handRight;

    public Animator anim;
    public LineRenderer lineRend;

    public float speed = 6.0f;
    public float sprintSpeed;
    private float startSpeed;

    public bool isAiming = false;
    public bool isMoving = false;

    public Transform aimingAt;
    void Start()
    {
        startSpeed = speed;
    }

    void Update()
    {
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            aimingBody.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            var emission = sprintPS.emission;
            emission.rateOverTime = 20;
        }
        else
        {
            speed = startSpeed;
            var emission = sprintPS.emission;
            emission.rateOverTime = 10;
        }
    }

    void aiming()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            aimingBody.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}