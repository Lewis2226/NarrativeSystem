using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOrVillain : MonoBehaviour
{
    // Declaramos una variable del tipo enum
   [SerializeField] private States.playerStates PlayerState;
   [SerializeField] private int GoodPoints;
   [SerializeField] private int BadPoints;
   [SerializeField] private string EventChoosen;
    private Aftermath aftermath;

    void Start()
    {
        PlayerState = States.playerStates.Neutral;
        aftermath = GetComponent<Aftermath>();
        Debug.Log(ShowNarrative());
    }

    public void SetState(States.playerStates NewState)
    {
        PlayerState = NewState;
    }

   public States.playerStates GetState()
   {
        return PlayerState;
   }

   public void SetPoints(States.playerStates PointsType, int amount)
   {
        if(PointsType == States.playerStates.Good)
        {
            GoodPoints += amount;
        }
        else
        {
            BadPoints += amount;
        }
   }

   public int GetPoints(States.playerStates PointsType)
   {
        if (PointsType == States.playerStates.Good)
        {
            return GoodPoints;
        }
        else
        {
            return BadPoints;
        }
   }

   public string ShowNarrative()
   {
        string EventToShow = aftermath.ShowNarrativeDialogue(2,PlayerState);
        return "Se eligió este evento " + EventToShow;
   }
}
