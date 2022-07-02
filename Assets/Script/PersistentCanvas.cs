using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() 
    { 
        int numberOfCanvases = FindObjectsOfType<PersistentCanvas>().Length; 
        if (numberOfCanvases > 1) 
        { 
            Destroy(gameObject); 
        } else 
        { DontDestroyOnLoad(gameObject);
        
        } 
    }
}
