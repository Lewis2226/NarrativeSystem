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

    void Start()
    {
        PlayerState = States.playerStates.Neutral;

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

   public string ShowNarrative(int NumberEvent)
   {
        string EventChoosen;
        string EventToShow;
        switch(NumberEvent)
        {
            case 0:
                if(PlayerState == States.playerStates.Good)
                {
                    EventChoosen = "Hola, que hace?";
                    
                }
                else
                {
                    EventChoosen = "No me hables";
                    
                }
                EventToShow = EventChoosen;
                break;

            case 1:
                if (PlayerState == States.playerStates.Good)
                {
                    EventChoosen = "No puede ser";
                    
                }
                else
                {
                    EventChoosen = "Alejate , por favor";
                    
                }
                EventToShow = EventChoosen;
                break;

            case 2:
                if (PlayerState == States.playerStates.Good)
                {
                    EventChoosen = "Adios";
                    
                }
                else
                {
                    EventChoosen = "Largo de aqui";
                    
                }
                EventToShow = EventChoosen;
                break;

            default:
                EventToShow = "No existe ese evento";
                break;
        }

        return "Se eligió este evento " + EventToShow;
    }
}
