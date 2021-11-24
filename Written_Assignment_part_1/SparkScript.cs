using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkScript : MonoBehaviour
{
    public float timeleft;
    public Vector3 lookingDir;

    private void Start()
    {
        transform.LookAt(lookingDir);
    }
    private void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft < 0)
        {
            Destroy(gameObject);
        }
    }
}