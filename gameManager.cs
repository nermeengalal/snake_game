using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//public enum PreRequirments
//{
//    Timer,
//    Moves
//}
////unity cant show custom classes in inspector without it
//[System.Serializable]
//public class Requirmnets
//{
//    public PreRequirments pre;
//    public  float Value;
//}
public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public static float Value;

    public World world;
   // public  int level=0;
    public Text value ;
    Score S;
    // Start is called before the first frame update
    void Start()
    {
        S = GameObject.Find("Game Manager").GetComponent<Score>();
        if (world != null)
        {
            Value = world.levels[PlayerPrefs.GetInt("Level")].TimerValue;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        value.text =((int) Value).ToString();

        if (Value > 0)
        {
            Value -= Time.deltaTime;
            if (Value <= 0)
            {
                Value = 0;
                S.Lost();

            }
        }
    }
    
}
