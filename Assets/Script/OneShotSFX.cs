using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSFX : MonoBehaviour
{
    // Start is called before the first frame update
    public float destructionDelay = 2;
    void Start()
    {
        Destroy(gameObject, destructionDelay);
        
    }

    // Update is called once per frame
    
}
