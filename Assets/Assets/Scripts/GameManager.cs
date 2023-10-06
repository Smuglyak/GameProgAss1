using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
// Write down your variables here
    public static float Score = 0;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself. 
        if (Instance != null && Instance != this)
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
        DontDestroyOnLoad(Instance);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void IncrementScore()
    {
        // TODO Increment score logic and win condition 
        ScoreBehavior.scoreValue += 50;
        Score += 50; 
        Debug.Log(Score);   
        if(Score >= 150)
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            NextLevel();
        }
    }

    public void resetScore() {
        Score = 0;
        Debug.Log("elo");
    }

    public float getScore() {
        return Score;
    }
}
