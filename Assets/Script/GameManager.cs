using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int gold = 0;
    Text goldText;
    public int lives = 3; 
    Text livesText;
    public GameObject playerPrefab;
    void Start()
    {
        goldText = GameObject.Find("GoldText").GetComponent<Text>();
        livesText = GameObject.Find("LivesText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void countMoney(int goldFound)
    { 
        gold += goldFound;
        goldText.text = "Apples: " + gold;
        Debug.Log("Collected " + goldFound + " gold. New total: " + gold + " gold"); 
    }
    public void EditLives(int lifeChange) 
    { 
        lives += lifeChange;

        if (lives > 0) 
        { 
            livesText.text = "Lives: " + lives; SpawnPlayer(); 
        } else 
        { 
            livesText.text = ""; 
            goldText.text = ""; 
            SceneManager.LoadScene("Lose Screen"); 
        }
        
    }

    private void SpawnPlayer() 
    { 
        GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity); 
        CinemachineVirtualCamera theCamera = FindObjectOfType<CinemachineVirtualCamera>(); 
        theCamera.Follow = newPlayer.transform; 
        CinemachineBrain theBrain = FindObjectOfType<CinemachineBrain>(); 
        theBrain.m_WorldUpOverride = newPlayer.transform; 
        
    }
    private void Awake() 
    { 
        SpawnPlayer(); 
        SetUpSingleton();
    }
    private void SetUpSingleton() 
    { 
        int numberOfGameSessions = FindObjectsOfType<GameManager>().Length; 
        if (numberOfGameSessions > 1) 
        { 
            Destroy(gameObject); 
        } else 
        { 
            DontDestroyOnLoad(gameObject); 
        } 
    }
}
