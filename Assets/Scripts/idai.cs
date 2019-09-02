using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idai : MonoBehaviour
{
    public GameObject viado;
    public Player boiola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            boiola = collision.GetComponent<Player>();

            if (boiola.keyCount == 3)
            {
                collision.GetComponent<Player>().VictoryPanel();
            }
        }
    }
}
