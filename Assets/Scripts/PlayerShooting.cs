using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    int bulletLayer;
    public GameObject bulletPrefab;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    public float delayShooting = 5f;
    float cooldownShooting = 0;
    void Start(){
        bulletLayer = gameObject.layer;
    }
    // Update is called once per frame
    void Update()
    {
        cooldownShooting -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownShooting <= 0){
            cooldownShooting = delayShooting;
            Vector3 offset = transform.rotation * bulletOffset;
            GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            bulletGo.layer = bulletLayer;
        }
    }
}
