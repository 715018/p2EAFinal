using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   private int score = 0;
    private int lives = 3;
    public GameObject pauseScreen; 
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the user has pressed the P key 
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    public void AddLives(int value)
    {
        lives += value;
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            lives = 0;
        }
        Debug.Log("Lives = " + lives);
    }
    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }

    void ChangePaused() 
    { 
        if(!paused)
        {
            paused =true;
            pauseScreen.SetActive(true); 
            Time.timeScale = 0; 
        } 
        
        else 
        {
            paused =false; 
            pauseScreen.SetActive(false); 
            Time.timeScale = 1; 
        } 
    }
}


