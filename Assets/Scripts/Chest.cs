using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
    public bool playerContact;
    public GameObject[] Items;
    public int[] RollChance;
    public int dice;
    public Transform SpawnPoint;
    public bool isClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && playerContact == true && isClosed == true)
        {
            anim.SetBool("IsOpen", true);
            isClosed = false;
            RollItems();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerContact = false;
        }
    }

    public void RollItems()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            dice = Random.Range(0, 100);
            if(dice <= RollChance[i])
            {
                Instantiate(Items[i], SpawnPoint.position, Quaternion.identity);
            }
        }
    }
}
