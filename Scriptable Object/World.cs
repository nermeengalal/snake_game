using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "World")]    //to add taG 
public class World : ScriptableObject
{
    public Level[] levels;
}
