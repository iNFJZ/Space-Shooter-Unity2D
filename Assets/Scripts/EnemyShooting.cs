using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float delayShooting = 2f;
    float cooldownShooting = 0;
    // Update is called once per frame
    void Update()
    {
        cooldownShooting -= Time.deltaTime;
        if(cooldownShooting <= 0){
            cooldownShooting = delayShooting;
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
