using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    // Start is called before the first frame update
    public int healingValue = 5; 
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        Player player = collision.gameObject.GetComponent<Player>(); 
        if (player != null) 
        {
            player.AddHealth(healingValue); 
            Destroy(gameObject); 
        } 
    }
}
