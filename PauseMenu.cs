using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Player p;
    public Sprite PlaySprite,SoundOn;
    public Sprite PauseSprite,SoundOff;
    public GameObject pauseMenu;
    public Button Soundbtn;
    Button pause; 
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pause = GetComponent<Button>();
        p = GameObject.Find("Character").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pause.image.sprite = PlaySprite;
        }
        else if (Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            pause.image.sprite = PauseSprite;
        }

    }
    public void Sound()
    {
        if(p.Eating.volume==1)
        {
            p.Eating.volume = 0;
            Soundbtn.image.sprite=SoundOff;
        }
        else if(p.Eating.volume==0)
        {
            Soundbtn.image.sprite = SoundOn;
            p.Eating.volume = 1;
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("Intro");
        Time.timeScale = 1;
    }
}
