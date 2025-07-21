using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class HistoryDialogue
{
    public int id;
    public string goodDialogue;
    public string badDialogue;
}

[System.Serializable]
public class DialogueInteraction
{
    public int id;
    public string saveDialogue;
    public string truthDialogue;
    public string killDialogue;
    public string lieDialogue;
}

[System.Serializable]
public class DialogueNPCs
{
    public int id;
    public string StartDialogue;
    public string MidDialogue;
    public string EndDialogue;
}

[System.Serializable]
public class DialogueSequences
{
    public int id;
    public string Dialogue;
    public int nextID;
}

public class DialogueManager : MonoBehaviour
{
    public List<HistoryDialogue> dialoguesHistory;
    public List<DialogueInteraction> dialoguesInteraction;
    public List<DialogueNPCs> dialoguesNPCs;
    public List<DialogueSequences> dialoguesSequence;
    public TextAsset dialoguesHeroOrVillan;
    public TextAsset dialoguesInterations;
    public TextAsset dialoguesNPcs;
    public TextAsset dialogueSequences;
    public TextMeshProUGUI textDialogue;
    public TextMeshProUGUI textDialogueNPC;
    private float typewriterSpeed = 0.2f;
    private int currentDialogueID = 1;
    private string currentDialogue;
    private bool isTyping = false;
    private bool canSkip = false;


    private void Start()
    {
        ReadCSV(dialoguesHeroOrVillan, 1);
        ReadCSV(dialoguesInterations, 2);
        ReadCSV(dialoguesNPcs, 3);
        ReadCSV(dialogueSequences, 4);
        StartCoroutine(Typewriter(ShowDialogueSequences(1)));

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
                    DialogueInteraction dialogue = new DialogueInteraction();
                    dialogue.id = int.Parse(data[0]);
                    dialogue.saveDialogue = data[1];
                    dialogue.truthDialogue = data[2];
                    dialogue.killDialogue = data[3];
                    dialogue.lieDialogue = data[4];
                    dialoguesInteraction.Add(dialogue);

                    
                }
                break;

                case 3: //Diálogos NPCs
                  for(int i = 1; i < lines.Length; i++)
                  {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] data = line.Split(",");
                    DialogueNPCs dialogue = new DialogueNPCs();
                    dialogue.id= int.Parse(data[0]);
                    dialogue.StartDialogue = data[1];
                    dialogue.MidDialogue = data[2];
                    dialogue.EndDialogue = data[3];
                    dialoguesNPCs.Add(dialogue);
                  }
                break;

                case 4: //Diálogos Sequenciales
                  for (int i = 1; i < lines.Length; i++)
                  {
                    string line = lines[i];
                    if (string.IsNullOrEmpty(line)) continue;
                    string[] data = line.Split(",");
                    DialogueSequences dialogue = new DialogueSequences();
                    dialogue.id = int.Parse(data[0]);
                    dialogue.Dialogue = data[1];
                    dialogue.nextID = int.Parse(data[2]);
                    dialoguesSequence.Add(dialogue);
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

    public string GetDialogueInteraction(int id, Action.playerActions actionstype)
    {
        DialogueInteraction dialogue;

        if (id >=1 && id <= 5)
        {
            //Primer nivel
            dialogue = dialoguesInteraction.Find(d => d.id == 1);
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
            dialogue = dialoguesInteraction.Find(d => d.id == 10);
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
            dialogue = dialoguesInteraction.Find(d => d.id == 15);
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
            dialogue = dialoguesInteraction.Find(d => d.id == 20);
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


    public string GetDialogueNPCs(int GameLevel)
    {
        int ramdonID = UnityEngine.Random.Range(1, dialoguesNPCs.Count);
        DialogueNPCs dialogue = dialoguesNPCs.Find(d => d.id == ramdonID);

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

    public string GetDialogueSequence(int id)
    {
        DialogueSequences dialogue = dialoguesSequence.Find(d => d.id == id);
        if (dialogue != null)
        {
            currentDialogue = dialogue.Dialogue;
            currentDialogueID = dialogue.nextID;
            isTyping = true;
            canSkip = false;
            return currentDialogue;
        }
        return "";
    }

    public void NextDialogueSequence()
    {
        if(currentDialogueID != 0)
        {
            StartCoroutine(Typewriter(ShowDialogueSequences(currentDialogueID)));
        }
        else
        {
            Debug.Log("Ya no hay dialogos");
        }
    }

    public void SkipDialogueSequence()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            textDialogue.text = currentDialogue;
            isTyping = false;
            canSkip= true;
        }
        else if (canSkip || !isTyping)
        {

            ShowDialogueSequences(currentDialogueID);
        }
    }


    public string ShowDialogue(int dialogueId, States.playerStates dialogueState) //Para dialogos narrativos
    {
        string dialogueToShow = GetDialogueNarratve(dialogueId, dialogueState);
        return dialogueToShow;
    }


    public string ShowDialogue(int level, Action.playerActions actionType) //Para dialogos de interraciones
    {
        string dialogueToShow = GetDialogueInteraction(level, actionType);
        return dialogueToShow;
    }


    public string ShowDialogue(int GameLevel) //Para dialogos los NPCs
    {
        string dialogueToShow = GetDialogueNPCs(GameLevel);
        return dialogueToShow;
    }

    public string  ShowDialogueSequences(int DialogueID) //Para los eventos
    {
        string dialogueToShow = GetDialogueSequence(DialogueID);
        return dialogueToShow; 
    }

   
    private IEnumerator Typewriter(string Dialogue)
    {
        textDialogue.text = "";
        foreach (char letter in Dialogue)
        {
            textDialogue.text += letter;
            yield return new WaitForSeconds(typewriterSpeed);
        }

        isTyping = false;
    }

    


    public void ShowHD()
    {
        StartCoroutine(Typewriter(ShowDialogue(7, States.playerStates.Good)));
    }

    public void ShowVD()
    {
        StartCoroutine(Typewriter(ShowDialogue(7, States.playerStates.Good)));
    }

    public void ShowSD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Save);;
    }
    public void ShowTD() 
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Truth);
    }

    public void ShowKD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Kill);
    }

    public void ShowLD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Lie);
    }
}
