using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager oldGameManager = FindObjectOfType<GameManager>(); 
        if (oldGameManager != null)
            Destroy(oldGameManager.gameObject); 
        
        PersistentCanvas oldPersistentCanvas = FindObjectOfType<PersistentCanvas>(); 
        if (oldPersistentCanvas != null) 
            Destroy(oldPersistentCanvas.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
            RestartGame();
        
    }
    public void RestartGame() { SceneManager.LoadScene("Level 1"); }
}
