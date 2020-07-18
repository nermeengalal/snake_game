using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    Panels P;
    public static int CurrentScore = 0;
    public static int ScoreNeeded = 0;
    public Text result;
    public World world;
    public  GameObject win ,lose;
    public static bool isLost = false ,isWin=false;
  
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore = 0;
        P = GameObject.Find("Canvas").GetComponent<Panels>();
        if (world != null)
        {
            ScoreNeeded = world.levels[PlayerPrefs.GetInt("Level")].score;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
        //win.SetActive(false);
       // lose.SetActive(false); 
        ///();
        result.text =  CurrentScore.ToString()+" / " + ScoreNeeded.ToString();
    }

   
   public void Win()
   {
        if (CurrentScore >= ScoreNeeded && gameManager.Value >= 0)
        {
            Player.MoveSpeed = 0;
            win.SetActive(true);
            P.level+=1;
            Debug.Log(P.level);
            PlayerPrefs.SetInt("Level", P.level);
        }
        //IntroLevel.btn[PlayerPrefs.GetInt("Level")].enabled = true;
    
   }

    public void Lost()
    {
        if (CurrentScore < ScoreNeeded && gameManager.Value == 0)
        {
          
            Player.isDead = true;
            lose.SetActive(true);
        }
        if (Player.isDead == true)
        {
            gameManager.Value = 0;
            lose.SetActive(true);
        }
    }
}
