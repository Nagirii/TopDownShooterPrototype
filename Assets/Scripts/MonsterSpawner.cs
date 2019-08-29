using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public Transform spawnPoint;
    public int spawnNumber;
    public float spawnTime;
    public float spawnDelay;
    public bool stopSpawning = false;
    public int count;
    public int maxSpawn;

    
    private void Start(){
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Instantiate(monster, spawnPoint.position, Quaternion.identity);
            count = count + 1;
            if(count >= maxSpawn)
            {
                stopSpawning = true;
            }
            if (stopSpawning == true)
            {
                CancelInvoke("Spawn");
            }

        }
    }
    
}
