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
    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
       
        dialogueManager = GetComponent<DialogueManager>();
        ChangePlayerState(13, 5, 1);
        //playerStates = States.playerStates.Bad;
        Debug.Log(playerStates);
        ShowHistoryDialogue();
        NPCsDialogue();
        ChangeWorld(playerStates, 1);
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
                    Debug.Log("Se termino el primer capítulo como heróe");
                }
                else if(villanPoints >heroPoints && villanPoints >= 10 )
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 5;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el primer capítulo como villano");
                }    
            break;

            case 2:
                if(heroPoints > villanPoints && heroPoints >= 20)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 10;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el segundo capítulo como heróe");
                }
                else if(villanPoints> heroPoints && villanPoints >= 20)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 10;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el segundo capítulo como villano");
                }
            break;

            case 3:
                if (heroPoints > villanPoints && heroPoints >= 30)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 15;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el tercer capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 30)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 15;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el tercer capítulo como villano");
                }
            break;

            case 4:
                if(heroPoints > villanPoints && heroPoints >= 40)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 20;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el cuarto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 40)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal =20;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el cuarto capítulo como villano");
                }
            break;

            case 5:
                if(heroPoints > villanPoints && heroPoints >= 50)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 25;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el quinto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 50)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 25;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el quinto capítulo como villano");
                }
            break;

            case 6:
                if(heroPoints > villanPoints && heroPoints >= 60)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 30;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el sexto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >=60)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 30;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el sexto capítulo como villano");
                }
            break;

            case 7:
                if(heroPoints > villanPoints && heroPoints >= 70)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 35;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el septimo capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 70)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 35;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el septimo capítulo como villano");
                }
            break;

            case 8:
                if(heroPoints > villanPoints && heroPoints >= 80)
                {
                    playerStates = States.playerStates.Good;
                    Debug.Log("Se termino el octavo capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 80)
                {
                    playerStates = States.playerStates.Bad;
                    Debug.Log("Se termino el octavo capítulo como villano");
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

    private void ChangeWorld(States.playerStates playerState , int GameLevel)
    {
        switch(GameLevel)
        {
            case 1:
                if(playerState == States.playerStates.Good)
                {
                  Debug.Log("El mundo cambio por ser bueno");
                }
                else if(playerState == States.playerStates.Bad)
                {
                  Debug.Log("El mundo cambio por ser malo");
                }
            break;

            default:
                Debug.Log("No se encuentra ese nivel Narrativo");
            break;      


        }
    }

    void ShowHistoryDialogue()
    {
         dialogueManager.ShowDialogue(1, playerStates);
        // dialogueManager.ShowIcon(playerStates);
    }

    void NPCsDialogue()
    {
        dialogueManager.ShowDialogue(1);
    }
}
