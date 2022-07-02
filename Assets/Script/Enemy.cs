using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f; 
    Player thePlayer;
    public int damage = 2;
    public GameObject SFXPrefab;

    // Update is called once per frame
    void Update()
    {
       if (thePlayer == null) 
       {
           FindPlayer(); 
        } else { MoveTowardPlayer(); }
        
    }
   private void OnTriggerEnter2D(Collider2D collision) 
   {
       SwordBlur swordBlur = collision.GetComponent<SwordBlur>(); 
       if (swordBlur == null) return; 
       if (SFXPrefab != null) 
            Instantiate(SFXPrefab, transform.position, Quaternion.identity);
       Destroy(gameObject);
   }
   private void OnCollisionEnter2D(Collision2D collision) 
   { 
       Player player = collision.gameObject.GetComponent<Player>(); 
       if (player != null) 
       { 
           player.AddHealth(-damage); 
        } 
    }
    void FindPlayer() { thePlayer = FindObjectOfType<Player>(); }
    void MoveTowardPlayer() 
    { //Get the current Player and Enemy positions 
    Vector3 playerPosition = thePlayer.transform.position; 
    Vector3 enemyPosition = transform.position; 
    //Subtract the vectors to find the vector between the two 
    Vector3 difference = playerPosition - enemyPosition; 
    //Normalize the vector so it is direction only 
    Vector3 chaseDirection = difference.normalized; 
    //Send the ghost toward the player at the set speed. 
    GetComponent<Rigidbody2D>().velocity = chaseDirection * speed; 
    //Turn toward the player. Lots of math happening here. 
    float angle = Mathf.Atan2(chaseDirection.y, chaseDirection.x) * Mathf.Rad2Deg - 90; 
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
    }
}
       
    
