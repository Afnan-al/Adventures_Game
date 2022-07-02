using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        Player player = collision.GetComponent<Player>(); 
        // If the other object is the player... 
        if (player != null) 
        { 
            // Determine next scene index 
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; 
            // Load that scene 
            SceneManager.LoadScene(nextSceneIndex); 
        } 
    }
}
