using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int goldValue = 0;
    public GameObject SFXPrefab;
    private void OnCollisionEnter2D(Collision2D collision) 
    { 
        Player player = collision.gameObject.GetComponent<Player>(); 
        if (player == null) return;

        if (SFXPrefab != null) 
            Instantiate(SFXPrefab, transform.position, Quaternion.identity);
        
        FindObjectOfType<GameManager>().countMoney(goldValue); 
        Destroy(gameObject);
    }
}
