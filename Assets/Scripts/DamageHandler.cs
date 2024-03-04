using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    float invulnerability = 0;
    int correctLayer;

    void Start(){
        correctLayer = gameObject.layer;
    }
    void OnTriggerEnter2D(){
        Debug.Log("Trigger!");
        health--;
        invulnerability = 1f;
        gameObject.layer = 8;
    }

    void Update(){
        invulnerability -= Time.deltaTime;
        if(invulnerability <= 0){
            gameObject.layer = correctLayer;
        }
        if(health <= 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
