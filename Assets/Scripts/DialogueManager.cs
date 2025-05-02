using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class HistoryDialogue
    {
        public int id;
        public string goodDialogue;
        public string badDialogue;
    }

    [System.Serializable]
    public class DialogueInterration
    {
        public int id;
        public string saveDialogue;
        public string truthDialogue;
        public string killDialogue;
        public string lieDialogue;
    }

    public TextAsset DialoguesNarrative;
    public TextAsset DialoguesInterration;
    public List<HistoryDialogue> dialoguesHistory;
    public List<DialogueInterration> dialoguesInterration;
    



    // Start is called before the first frame update
    void Start()
    {
        ReadCSV(DialoguesInterration, 2);
        ShowDialogue(2, Action.playerActions.Save);

    }

    public void ReadCSV(TextAsset DialoguesList, int DialoguesTypes)
    {
        string[] lines = DialoguesList.text.Split('\n');
        switch (DialoguesTypes)
        {
            case 1: //Di�logos Narrativos
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] data = line.Split(',');

                    HistoryDialogue dialogue = new HistoryDialogue();
                    dialogue.id = int.Parse(data[0]);
                    dialogue.goodDialogue = data[1];
                    dialogue.badDialogue = data[2];

                    dialoguesHistory.Add(dialogue);
                }

                Debug.Log("Se encontraron : " + dialoguesHistory.Count + " lineas de dialogo de narrativa");
                break;

                case 2: //Di�logos Interraciones
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] data = line.Split(',');
                    DialogueInterration dialogue = new DialogueInterration();
                    dialogue.id = int.Parse(data[0]);
                    dialogue.saveDialogue = data[1];
                    dialogue.truthDialogue = data[2];
                    dialogue.killDialogue = data[3];
                    dialogue.lieDialogue = data[4];
                    dialoguesInterration.Add(dialogue);
                }
                Debug.Log("Se encontraron : " + dialoguesInterration.Count + " lineas de dialogo de interraciones");
                break;


            default: //No se reconoce el tipo de di�logos
                Debug.Log("No existe se tipo de dialogos");
                break;

        }
       
    }

    public string GetDialogueNarratve(int id, States.playerStates Statetypes)
    {
        HistoryDialogue dialogue = dialoguesHistory.Find(d => d.id == id);

        if(dialogue == null)
        {
            Debug.Log("No se encontro se di�logo con el " + id);
            return "";
        }

        switch (Statetypes)
        {
            case States.playerStates.Good:
                return dialogue.goodDialogue;
                

            case States.playerStates.Bad:
                return dialogue.badDialogue;

            default:
                Debug.Log("Tipo inv�lido, no se reconoce");
                return "";
        }
    }

    public string GetDialogueInterration(int id, Action.playerActions actionstype)
    {
        DialogueInterration dialogue;

        if (id >=1 && id <= 5)
        {
            Debug.Log("Primer nivel");
            dialogue = dialoguesInterration.Find(d => d.id == 1);
            switch (actionstype)
            {
                case Action.playerActions.Save:
                    return dialogue.saveDialogue;

                case Action.playerActions.Truth: 
                    return dialogue.truthDialogue;

                case Action.playerActions.Kill:
                    return dialogue.killDialogue;

                case Action.playerActions.Lie:
                    return dialogue.lieDialogue;

                default:
                    Debug.Log("Tipo inv�lido, no se reconoce");
                    return "";
            }
        }

        else if (id > 5 && id <=10 )
        {
            Debug.Log("Segundo nivel nivel");
            dialogue = dialoguesInterration.Find(d => d.id == 10);
            switch (actionstype)
            {
                case Action.playerActions.Save:
                    return dialogue.saveDialogue;

                case Action.playerActions.Truth:
                    return dialogue.truthDialogue;

                case Action.playerActions.Kill:
                    return dialogue.killDialogue;

                case Action.playerActions.Lie:
                    return dialogue.lieDialogue;

                default:
                    Debug.Log("Tipo inv�lido, no se reconoce");
                    return "";
            }
        }

        else if (id > 10 && id <= 15)
        {
            Debug.Log("Tercer nivel");
            dialogue = dialoguesInterration.Find(d => d.id == 15);
            switch (actionstype)
            {
                case Action.playerActions.Save:
                    return dialogue.saveDialogue;

                case Action.playerActions.Truth:
                    return dialogue.truthDialogue;

                case Action.playerActions.Kill:
                    return dialogue.killDialogue;

                case Action.playerActions.Lie:
                    return dialogue.lieDialogue;

                default:
                    Debug.Log("Tipo inv�lido, no se reconoce");
                    return "";
            }
        }

        else if (id > 15 && id < 20 )
        {
            Debug.Log("Cuarto nivel nivel");
            dialogue = dialoguesInterration.Find(d => d.id == 20);
            switch (actionstype)
            {
                case Action.playerActions.Save:
                    return dialogue.saveDialogue;

                case Action.playerActions.Truth:
                    return dialogue.truthDialogue;

                case Action.playerActions.Kill:
                    return dialogue.killDialogue;

                case Action.playerActions.Lie:
                    return dialogue.lieDialogue;

                default:
                    Debug.Log("Tipo inv�lido, no se reconoce");
                    return "";
            }
        }

        else
        {
            Debug.Log("No encuentro es nivel");
            return "";
        }
    }

    public string ShowDialogue(int dialogueId, States.playerStates dialogueState) //Para dialogos narrativos
    {
        string dialogueToShow = GetDialogueNarratve(dialogueId, dialogueState);
        Debug.Log("Di�logo: " + dialogueToShow);
        return dialogueToShow;
    }

    public string ShowDialogue(int level, Action.playerActions actionType)
    {
        string dialogueToShow = GetDialogueInterration(level, actionType);
        Debug.Log("Di�logo: " + dialogueToShow);
        return dialogueToShow;
    }

}
