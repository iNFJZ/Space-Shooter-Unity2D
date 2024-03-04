using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVPlayer : MonoBehaviour
{
    public Transform pov;
    // Update is called once per frame
    void Update()
    {
        if(pov != null){
            Vector3 camPov = pov.position;
            camPov.z = transform.position.z;
            transform.position = camPov;
        }
    }
}
