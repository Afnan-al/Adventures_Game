using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBlur : MonoBehaviour
{
    // Start is called before the first frame update
    public float destructionDelay = 0.02f;
    public GameObject SFXPrefab;
    void Start()
    {
        if (SFXPrefab != null) 
            Instantiate(SFXPrefab, transform.position, Quaternion.identity);

        StartCoroutine(Death());

        
    }

    // Update is called once per frame
    IEnumerator Death() 
    { 
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject); 
    }
}
