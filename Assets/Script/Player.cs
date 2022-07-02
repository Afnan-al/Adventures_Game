using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    public float speed = 5;
    public GameObject swordPrefab;
    public int health = 20; 
    int maxHealth;
    Slider theSlider;
    GameManager theManager;
    public GameObject HurtSFXPrefab;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        maxHealth = health;
        theSlider = FindObjectOfType<Slider>();
        theManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical"); 
        Vector2 moveVelocity = new Vector2(moveX, moveY); myRigidbody.velocity = moveVelocity * speed;
        if (moveVelocity != Vector2.zero) 
        {
             float angle = Mathf.Atan2(moveVelocity.y, moveVelocity.x) * Mathf.Rad2Deg - 90; 
             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (Input.GetKeyDown("space")) 
        { 
            Instantiate(swordPrefab, transform.position, transform.rotation); 
        }
    }
    public void AddHealth(int healthPoints) 
    { 
        if (healthPoints < 0 && HurtSFXPrefab != null) 
            Instantiate(HurtSFXPrefab, transform.position, Quaternion.identity);
        health += healthPoints; 
        Debug.Log("Health changed by " + healthPoints + " -- new health is " + health); 
        UpdateUI();
        if (health <= 0) 
        { 
            Die(); 
        }
    }
    private void Die() 
    {
        theManager.EditLives(-1); 
        Destroy(gameObject); 
    }
    private void UpdateUI() 
    { 
        theSlider.value = (float)health / maxHealth; 
    }
}
