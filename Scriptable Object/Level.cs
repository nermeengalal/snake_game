using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Level")]
public class Level : ScriptableObject
{
    [Header("Timer")]
    //public float Time;
    public float TimerValue;
    public int score;
}
