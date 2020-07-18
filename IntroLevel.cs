using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroLevel : MonoBehaviour
{
    public static IntroLevel instance;

    public int Levelno;
   
    public Text Number;
    // Start is called before the first frame update
    void Start()
    {
        Number.text = Levelno.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
    }
    public void EnterLevel()
    {
        if (Levelno < 4)
        {
            PlayerPrefs.SetInt("Level", Levelno - 1);
            Player.isDead = false;
            SceneManager.LoadScene("SampleScene");
        }
        else if(Levelno >= 4)
        {
            PlayerPrefs.SetInt("Level", (Levelno % 4));
            Player.isDead = false;
            SceneManager.LoadScene("SampleScene");
        }
       // SceneManager.LoadScene("SampleScene");
    }
}
