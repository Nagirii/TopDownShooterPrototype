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

    public void TakeDamage(int damageAmount){
        health -= damageAmount;
        if(health <=0)
        { 
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
