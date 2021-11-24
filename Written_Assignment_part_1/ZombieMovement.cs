using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    public Transform goal;
    public Animator anim;
    public float timerDuration;
    private float timeStartDuration;
    private NavMeshAgent agent;
    private float startSpeed;

    void Start()
    {
        goal = GameObject.FindWithTag("Player").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        //anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        startSpeed = agent.speed;
        timeStartDuration = timerDuration;
    }
    private void Update()
    {
        agent.destination = goal.position;
        //Debug.Log(Vector3.Distance(goal.position, transform.position));
        if(Vector3.Distance(goal.position, transform.position) <= 0.5f)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", true);

            timerDuration -= Time.deltaTime;
            if (timerDuration <= 0)
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", false);
                timerDuration = timeStartDuration;
            }

        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isRunning", true);
            agent.speed = startSpeed;
        }

    }

}