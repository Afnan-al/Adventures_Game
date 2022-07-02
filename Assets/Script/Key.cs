using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string doorName= "Door";
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // First, check whether the other object is the player 
        // If it's not the player, then return early 
        Player player = collision.gameObject.GetComponent<Player>(); 
        if (player == null) return; 
        // If it was the player, then they have found the key. 
        // Get all the doors in the scene... 
        Door[] allDoors = FindObjectsOfType<Door>(); 
        // ...and loop through them, unlocking each one 
        foreach (Door door in allDoors) 
        {
            if(door.gameObject.name==doorName) 
                door.isLocked = false;
        } 
    }
}
