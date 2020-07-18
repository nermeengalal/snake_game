using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panels : MonoBehaviour
{
    public static Panels instance;
    public int level;
  
    public World world;
    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
    }
    private void Update()
    {
       
       
        
    }
    public void NextLevel()
    {

        if (world != null)
        {
            Debug.Log(level);
            SceneManager.LoadScene("SampleScene");
            Player.MoveSpeed = 1.5f;
            Score.CurrentScore = 0;
        }
    }

    public void Retry()
    {
        if (world != null)
        {
            gameManager.Value = world.levels[PlayerPrefs.GetInt("Level")].TimerValue;         
            Player.isDead = false;
            SceneManager.LoadScene("SampleScene");
            Player.MoveSpeed = 1.5f;
            Score.CurrentScore = 0;
        }

    }
    public void Back()
    {
        SceneManager.LoadScene("Intro");
    }
}
