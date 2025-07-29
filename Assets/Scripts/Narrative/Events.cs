using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stages", menuName = "ScriptableObjects/Etapas del juego", order = 1)]

public class Events : ScriptableObject
{
    public string eventName;
    public string moral;
    public int duration;
    public bool status;
    public bool completed;
    public TextAsset eventdialogues;

}
