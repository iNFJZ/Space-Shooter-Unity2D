using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    float invulnerability = 0;
    int correctLayer;
    private SpriteRenderer spriteRenderer;
    void Start(){
        correctLayer = gameObject.layer;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null){
            spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
            if(spriteRenderer == null){
            Debug.Log("Error'"+gameObject.name+"' has no sprite renderer");
        }
    }
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
            if(spriteRenderer != null){
                spriteRenderer.enabled = true;
            }
        }else{
            if(spriteRenderer != null){
                spriteRenderer.enabled = !spriteRenderer.enabled;
            }
        }
        if(health <= 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
