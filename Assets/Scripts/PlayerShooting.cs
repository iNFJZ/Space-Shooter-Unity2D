using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    float delayShooting = 1f;
    float cooldownShooting = 0f;
    // Update is called once per frame
    void Update()
    {
        cooldownShooting -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownShooting <= 0){
            Debug.Log("Shooting!");
            cooldownShooting = delayShooting;
        }
    }
}
