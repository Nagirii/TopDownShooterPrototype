using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monster;
    public Transform spawnPoint;
    public int spawnNumber;
    public float waitTime= 3f;
    
    private void Start(){
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            for(int i=0; i<spawnNumber; i++) {
                Instantiate(monster, spawnPoint.position, Quaternion.identity);
            }
        }
    }
    
}
