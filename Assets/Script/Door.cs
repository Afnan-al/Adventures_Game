using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isLocked;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // First check to see if the other object was the player 
        Player player = collision.gameObject.GetComponent<Player>();
        // If the other object was the player and the door is not locked, open it 
        if (player != null && !isLocked) 
        { 
            Destroy(gameObject); 
        }
    }
}
