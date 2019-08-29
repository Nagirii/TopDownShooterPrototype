using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public Vector3 size;
    public Vector3 center;
    public GameObject enemy;
    public int enemyAmount;
    BoxCollider2D col;
    public int enemiesRemaining;
    public GameObject[] enemies;
    public bool roomActive = false;
    public bool roomCleared = false;
    public int minEnemies;
    public int maxEnemies;



    public void Start()
    {
        col = GetComponent<BoxCollider2D>();
        enemyAmount = Random.Range(minEnemies, maxEnemies);
    }
    //Spawning Enemies
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
    public void Spawn()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
        Instantiate(enemy, pos, Quaternion.identity);

    }
       

    //Player entering the room
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(bazinga());
            for (int i=0; i<enemyAmount; i++)
            {
                Spawn();
            }
            roomActive = true;
        }
    }
    //Checking enemy numbers
    public void Update()
    {
        EnemyNumbersCheck();
    }
    public void EnemyNumbersCheck()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesRemaining = enemies.Length;
        if (enemiesRemaining == 0 && roomActive == true)
        {
            roomCleared = true;
            col.enabled = false;
        }
    }
    public IEnumerator bazinga()
    {
        float waitTime = 1.5f;
        yield return new WaitForSeconds(waitTime);
    }

}


