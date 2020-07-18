using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Sprite ActiveSprite;
    public Sprite LockedSprite;
    public Button[] btn;
    public bool[] isActive;
    int NoOFActive;
    // Start is called before the first frame update
    void Start()
    {
        NoOFActive =0;
        PlayerPrefs.GetInt("highLevel", 0).ToString();
    }

    // Update is called once per frame
    void Awake()
    {
        if (PlayerPrefs.GetInt("highLevel") > PlayerPrefs.GetInt("Level"))
        {
            for (int j = 0; j <= PlayerPrefs.GetInt("highLevel"); j++)
            {
                isActive[j] = true;
                btn[j].image.sprite = ActiveSprite;
            }

        }
        else if (PlayerPrefs.GetInt("highLevel") <= PlayerPrefs.GetInt("Level"))
        {
            int x= PlayerPrefs.GetInt("Level");
            PlayerPrefs.SetInt("highLevel",x);
            for (int j = 0; j <= PlayerPrefs.GetInt("highLevel"); j++)
            {
                isActive[j] = true;
                btn[j].image.sprite = ActiveSprite;
            }
        }
    }

    void Update()
    {
    for (int i = 0; i < btn.Length; i++)
        {
            if (isActive[i] == false)
            {
                btn[i].enabled = false;
                btn[i].image.sprite = LockedSprite;
            }
            else
                btn[i].enabled = true;
        }

    }
    public void back()
    {
        SceneManager.LoadScene("Start");
    }
}
