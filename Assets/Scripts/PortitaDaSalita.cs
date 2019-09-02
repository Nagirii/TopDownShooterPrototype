using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortitaDaSalita : MonoBehaviour
{
    RoomScript Room;
    BoxCollider2D coll;
    SpriteRenderer rend;
    Color c;

    private void Start()
    {
        Room = GetComponentInParent<RoomScript>();
        coll = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
    }
    //Checking if room is cleared
    private void Update()
    {
        if(Room.roomCleared == true || Room.roomActive != true)
        {
            coll.enabled = false;
            c.a = (0f);
            rend.material.color = c;
        }
        else 
        {
            coll.enabled = true;
            c.a = (1f);
            rend.material.color = c;
        }
    }

}
