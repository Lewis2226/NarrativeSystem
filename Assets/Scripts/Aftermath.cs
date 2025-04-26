using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aftermath : MonoBehaviour
{
    [SerializeField] private States.playerStates PlayerStatus;
    [SerializeField] private int HistoryLevel;
    [SerializeField] private string NarrativeDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetNarrativeLevel(int level)
    {
        HistoryLevel = level;
    }

    public int GetNarratuveLevel() 
    {
        return HistoryLevel;
    }

    public string ShowNarrativeDialogue(int level, States.playerStates NarrativeType)
    {
        string DialogueChoosen;
        switch (level)
        {
            case 0:
                if (NarrativeType == States.playerStates.Good)
                {
                    DialogueChoosen = "Hola, que hace?";

                }
                else
                {
                    DialogueChoosen = "No me hables";

                }
                NarrativeDialogue = DialogueChoosen;
                break;

            case 1:
                if (NarrativeType == States.playerStates.Good)
                {
                    DialogueChoosen = "No puede ser";

                }
                else
                {
                    DialogueChoosen = "Alejate , por favor";

                }
                NarrativeDialogue = DialogueChoosen;
                break;

            case 2:
                if (NarrativeType == States.playerStates.Good)
                {
                    DialogueChoosen = "Adios";

                }
                else
                {
                    DialogueChoosen = "Largo de aqui";

                }
                NarrativeDialogue = DialogueChoosen;
                break;

            default:
                NarrativeDialogue = "No existe ese evento";
                break;
        }

        return NarrativeDialogue;
    }
}
