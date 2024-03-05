using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float delaySpawn = 2f;
    float cooldownSpawn = 0;
    void Update()
    {
        if(Time.time >= cooldownSpawn){
            EnemySpawn();
            cooldownSpawn = Time.time + delaySpawn;
        }
    }

    void EnemySpawn(){
        float randomX = Random.Range(-10f, 10f);
        Vector3 enemyOffset = new Vector3(randomX, transform.position.y, 0);
        Instantiate(enemyPrefab, enemyOffset, Quaternion.identity);
    }
}
