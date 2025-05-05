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

    [System.Serializable]
    public class Dialogue
    {
        public int id;
        public string StartDialogue;
        public string MidDialogue;
        public string EndDialogue;
    }

    public TextAsset DialoguesNarrative;
    public TextAsset DialoguesInterration;
    public TextAsset DialoguesNPCs;
    public List<HistoryDialogue> dialoguesHistory;
    public List<DialogueInterration> dialoguesInterration;
    public List<Dialogue> dialoguesNPCs;
    



    // Start is called before the first frame update
    void Start()
    {
        ReadCSV(DialoguesNPCs,3);
        ShowDialogue(1);
        ShowDialogue(1);
        ShowDialogue(1);
        ShowDialogue(2);
        ShowDialogue(2);
        ShowDialogue(2);
        ShowDialogue(3);
        ShowDialogue(3);
        ShowDialogue(3);
    }

    public void ReadCSV(TextAsset DialoguesList, int DialoguesTypes)
    {
        string[] lines = DialoguesList.text.Split('\n');
        switch (DialoguesTypes)
        {
            case 1: //Diálogos Narrativos
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
                break;

               case 2: //Diálogos Interraciones
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
                break;

                case 3: //Diálogos NPCs
                  for(int i = 1; i < lines.Length; i++)
                  {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] data = line.Split(",");
                    Dialogue dialogue = new Dialogue();
                    dialogue.id= int.Parse(data[0]);
                    dialogue.StartDialogue = data[1];
                    dialogue.MidDialogue = data[2];
                    dialogue.EndDialogue = data[3];
                    dialoguesNPCs.Add(dialogue);
                  }
                break;

                default: //No se reconoce el tipo de diálogos
                Debug.Log("No existe se tipo de dialogos");
                break;

        }
       
    }

    public string GetDialogueNarratve(int id, States.playerStates Statetypes)
    {
        HistoryDialogue dialogue = dialoguesHistory.Find(d => d.id == id);

        if(dialogue == null)
        {
            return "";
        }

        switch (Statetypes)
        {
            case States.playerStates.Good:
                return dialogue.goodDialogue;
                

            case States.playerStates.Bad:
                return dialogue.badDialogue;

            default:
                Debug.Log("Tipo inválido, no se reconoce");
                return "";
        }
    }

    public string GetDialogueInterration(int id, Action.playerActions actionstype)
    {
        DialogueInterration dialogue;

        if (id >=1 && id <= 5)
        {
            //Primer nivel
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
                    Debug.Log("Tipo inválido, no se reconoce");
                    return "";
            }
        }

        else if (id > 5 && id <=10 )
        {
            //Segundo nivel
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
                    Debug.Log("Tipo inválido, no se reconoce");
                    return "";
            }
        }

        else if (id > 10 && id <= 15)
        {
            //Tercer nivel
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
                    Debug.Log("Tipo inválido, no se reconoce");
                    return "";
            }
        }

        else if (id > 15 && id < 20 )
        {
            //Cuarto nivel
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
                    Debug.Log("Tipo inválido, no se reconoce");
                    return "";
            }
        }

        else
        {
            Debug.Log("No encuentro es nivel");
            return "";
        }
    }


    public string GetDialogue(int GameLevel)
    {
        int ramdonID = UnityEngine.Random.Range(1, dialoguesNPCs.Count);
        Dialogue dialogue = dialoguesNPCs.Find(d => d.id == ramdonID);
        Debug.Log(ramdonID);

        switch (GameLevel) 
        {
            case 1: //dialogos del incio del juego
                return  dialogue.StartDialogue;

            case 2: //dialogos de la mitad del juego
                return  dialogue.MidDialogue;
                
            case 3: //dialogos del final del juego
                return dialogue.EndDialogue;

            default:
                Debug.Log("No se encuetro ese nivel del juego");
                return "";
        }
    }


    public string ShowDialogue(int dialogueId, States.playerStates dialogueState) //Para dialogos narrativos
    {
        string dialogueToShow = GetDialogueNarratve(dialogueId, dialogueState);
        Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }


    public string ShowDialogue(int level, Action.playerActions actionType)
    {
        string dialogueToShow = GetDialogueInterration(level, actionType);
        Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }


    public string ShowDialogue(int GameLevel) 
    {
        string dialogueToShow = GetDialogue(GameLevel);
        Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }
}
