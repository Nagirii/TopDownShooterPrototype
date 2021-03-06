﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public ParticleSystem deathParticle;
    public int damage;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Enemy"){
            collision.GetComponent<enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
        else if(collision.tag == "Wall")
        {
            DestroyProjectile();
        }
    }
}
