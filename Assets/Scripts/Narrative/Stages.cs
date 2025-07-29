using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stages", menuName = "ScriptableObjects/Etapas del juego", order = 0)]

public class Stages : ScriptableObject
{
    public string stageName;
    public int phases;
    public bool completed;
    public States.playerStates stateHowCompleted;
       
}
