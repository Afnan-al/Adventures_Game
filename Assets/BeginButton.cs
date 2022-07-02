using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadScene() 
    { 
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1; 
        SceneManager.LoadScene(nextSceneIndex); 
    }
}
