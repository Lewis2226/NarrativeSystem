using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stages", menuName = "ScriptableObjects/Etapas del juego", order = 0)]

public class Stages : ScriptableObject
{
    [Tooltip("Nombre para indetificar la etapa")]
    public string stageName;
    [Tooltip("Total de fase que tiene la etapa, debe tener al menos 1")]
    public int phases;
    private bool completed;
    [Tooltip("Estado en el cual se completa la fase")]
    public States.playerStates stateHowCompleted;
    [Tooltip("Lista de eventos que se agregan en esta fase")]
    public List<Events> toAdd;

    public bool GetComplete()
    {
        return completed;
    }

    public void SetComplete(bool complete)
    {
        completed = complete;
    }

    
}
