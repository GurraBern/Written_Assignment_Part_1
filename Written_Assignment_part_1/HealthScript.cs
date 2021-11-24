using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthPoints = 100;
    private int startHealthPoints;

    void Start()
    {
        startHealthPoints = healthPoints;
    }
}