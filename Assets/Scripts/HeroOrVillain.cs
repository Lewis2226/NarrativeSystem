using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOrVillain : MonoBehaviour
{
    // Declaramos una variable del tipo enum
    public States.playerStates PlayerState;

    void Start()
    {
        PlayerState = States.playerStates.Neutral;
        Debug.Log($"El estado del jugador es {PlayerState}");
    }

    void Update()
    {

    }
}
