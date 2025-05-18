using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public States.playerStates currentState;
    public States.playerStates playerStates;
    public int currentNarrativeLevel;
    public int heroPointsTotal;
    public int villanPointsTotal;
    public int[] actionsPointsTotal = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        ChangePlayerState(13, 5, 1);
    }

    public void ChangePlayerState(int heroPoints,int villanPoints,int level)
    {
        switch (level)
        {
            case 1: 
                if(heroPoints > villanPoints && heroPoints >= 10)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 5;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el primer cap�tulo como her�e");
                }
                else if(villanPoints >heroPoints && villanPoints >= 10 )
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 5;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el primer cap�tulo como villano");
                }    
            break;

            case 2:
                if(heroPoints > villanPoints && heroPoints >= 20)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 10;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el segundo cap�tulo como her�e");
                }
                else if(villanPoints> heroPoints && villanPoints >= 20)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 10;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el segundo cap�tulo como villano");
                }
            break;

            case 3:
                if (heroPoints > villanPoints && heroPoints >= 30)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 15;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el tercer cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 30)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 15;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el tercer cap�tulo como villano");
                }
            break;

            case 4:
                if(heroPoints > villanPoints && heroPoints >= 40)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 20;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el cuarto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 40)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal =20;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el cuarto cap�tulo como villano");
                }
            break;

            case 5:
                if(heroPoints > villanPoints && heroPoints >= 50)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 25;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el quinto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 50)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 25;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el quinto cap�tulo como villano");
                }
            break;

            case 6:
                if(heroPoints > villanPoints && heroPoints >= 60)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 30;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el sexto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >=60)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 30;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el sexto cap�tulo como villano");
                }
            break;

            case 7:
                if(heroPoints > villanPoints && heroPoints >= 70)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 35;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el septimo cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 70)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 35;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el septimo cap�tulo como villano");
                }
            break;

            case 8:
                if(heroPoints > villanPoints && heroPoints >= 80)
                {
                    playerStates = States.playerStates.Good;
                    Debug.Log("Se termino el octavo cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 80)
                {
                    playerStates = States.playerStates.Bad;
                    Debug.Log("Se termino el octavo cap�tulo como villano");
                }
            break;

            default:
                Debug.Log("No existe ese nivel narrativo");
            break;
        }
    }

    public void ActiveEvent()
    {

    }

    private void ChangeWorld()
    {

    }

    void ShowHistoryDialogue()
    {

    }

    void NPCDialogue()
    {

    }
}
