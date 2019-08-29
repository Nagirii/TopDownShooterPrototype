using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortitaDaSalita : MonoBehaviour
{
    RoomScript Room;
    BoxCollider2D coll;

    private void Start()
    {
        Room = GetComponentInParent<RoomScript>();
        coll = GetComponent<BoxCollider2D>();
    }
    //Checking if room is cleared
    private void Update()
    {
        if(Room.roomCleared == true || Room.roomActive != true)
        {
            coll.enabled = false;
        }
        else 
        {
            coll.enabled = true;
        }
    }

}
