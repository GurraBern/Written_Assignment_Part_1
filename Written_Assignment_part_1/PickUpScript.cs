using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject weaponAttatched;
    public GameObject handRight;
    public GameObject currentWeapon;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            handRight = other.GetComponent<MovementScript>().handRight;
            currentWeapon = handRight.transform.GetChild(0).gameObject;
            Destroy(currentWeapon);
            spawnWeaponAtHand();
        }
    }


    void spawnWeaponAtHand()
    {
        Instantiate(weaponAttatched, handRight.transform);
    }
}