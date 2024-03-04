using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float rotateSpeed = 180;

    float shipBoudaryRadius = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the ship
        // Grab our rotation quaternion
        Quaternion rotate = transform.rotation;
        // Grab the Z euler angle
        float z = rotate.eulerAngles.z;
        // Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        // Recreate the quanternion
        rotate = Quaternion.Euler(0,0,z);
        // Feed the quanternion to the rotation
        transform.rotation = rotate;

        //Move the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rotate * velocity; 

        //RESTRICT the player to camera's boudaries
        if(pos.y + shipBoudaryRadius > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - shipBoudaryRadius;
        }
        if(pos.y-shipBoudaryRadius < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + shipBoudaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrthographicSize = Camera.main.orthographicSize * screenRatio;
        if(pos.x + shipBoudaryRadius > widthOrthographicSize){
            pos.x = widthOrthographicSize - shipBoudaryRadius;
        } 
        if(pos.x - shipBoudaryRadius < -widthOrthographicSize){
            pos.x = -widthOrthographicSize + shipBoudaryRadius;
        }

        transform.position = pos;


    }
}
