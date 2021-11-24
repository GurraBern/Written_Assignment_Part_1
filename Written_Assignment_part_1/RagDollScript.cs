using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDollScript : MonoBehaviour
{

    public Rigidbody rb;
    private void Start()
    {
        rb.AddForce(0,0,30,ForceMode.Impulse);
    }

}
