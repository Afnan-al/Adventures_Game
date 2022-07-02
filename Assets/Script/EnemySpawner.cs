using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(1, 30)] 
    public int maxSpawns = 10; 
    //We will use this as a counter to track how many enemies have been spawned. 
    int totalSpawned = 0; //The range for the delay between spawns. 
    [Range(1,10)] 
    public float maxTimeDelay = 2; 
    //The object to be spawned. MUST be dragged from the Prefabs folder. 
    public GameObject enemyPrefab; 
    //Whether or not to continue spawning enemies. 
    bool active = true;
    IEnumerator Start() 
    { 
        // As long as this spawner is active, keep running the coroutine 
        // to delay the next spawn 
        while (active) { 
            // Determine how long to wait before the next spawn: the wait
            // can be anywhere between 1 second and maxTimeDelay seconds 
            float delay = Random.Range(1, maxTimeDelay); 
            yield return new WaitForSeconds(delay); 
            // When the wait is done, spawn an enemy 
            SpawnEnemy(); 
            //Increment the spawn counter 
            totalSpawned++; 
            // If this spawner has spawned enough, then it should stop 
            if (totalSpawned >= maxSpawns) 
                StopSpawning(); 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnEnemy() 
    { 
        Instantiate(enemyPrefab, transform.position, Quaternion.identity); 
    }
    public void StopSpawning() 
    {
        active = false; 
    }
}
