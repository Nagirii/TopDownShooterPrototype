using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health;
    public Transform player;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;
    public int attackSpeed;
    public int chance;
    public int roll;
    public GameObject drop;

    public void TakeDamage(int damageAmount){
        health -= damageAmount;
        if(health <=0)
        {
            roll = Random.Range(0, 100);
            if (roll <= chance)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
