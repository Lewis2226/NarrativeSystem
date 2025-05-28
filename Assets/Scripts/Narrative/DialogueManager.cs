using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
public class Dialogue
{
    public int id;
    public string StartDialogue;
    public string MidDialogue;
    public string EndDialogue;
}

public class DialogueManager : MonoBehaviour
{
    public List<HistoryDialogue> dialoguesHistory;
    public List<DialogueInteraction> dialoguesInteraction;
    public List<Dialogue> dialoguesNPCs;
    public TextAsset dialoguesHeroOrVillan;
    public TextAsset dialoguesInterations;
    public TextAsset dialoguesNPcs;
    public TextMeshProUGUI textDialogue;
    public TextMeshProUGUI textDialogueNPC;
    public Image StatusIcon;
    public Image ActionsIcon;
    public Color[] actionscolors = new Color[4]; 

    private void Start()
    {
        ReadCSV(dialoguesHeroOrVillan, 1);
        ReadCSV(dialoguesInterations, 2);
        ReadCSV(dialoguesNPcs, 3);
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

   /* public List<DialogueInterration> GetDialogueInterrationsList()
    {
        return dialoguesInterration; tengo que ver si puedo usar esto 
    }
   */

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


    public string GetDialogue(int GameLevel)
    {
        int ramdonID = Random.Range(1, dialoguesNPCs.Count);
        Dialogue dialogue = dialoguesNPCs.Find(d => d.id == ramdonID);

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
        //Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }


    public string ShowDialogue(int level, Action.playerActions actionType) //Para dialogos de interraciones
    {
        string dialogueToShow = GetDialogueInteraction(level, actionType);
        //Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }


    public string ShowDialogue(int GameLevel) //Para dialogos los NPCs
    {
        string dialogueToShow = GetDialogue(GameLevel);
        //Debug.Log("Diálogo: " + dialogueToShow);
        return dialogueToShow;
    }

    public void ShowIcon(States.playerStates Status)
    {

        StatusIcon.gameObject.SetActive(true);
        if (Status == States.playerStates.Good)
        {
            StatusIcon.color = Color.blue; 
        }

        else if (Status == States.playerStates.Bad)
        {
            StatusIcon.color= Color.red;
        }
        Invoke("HideIcons", 4);
    }

    public void ShowIcon(Action.playerActions ActionUse)
    {
        ActionsIcon.gameObject.SetActive(true);
        switch (ActionUse)
        {
            case Action.playerActions.Save:
                ActionsIcon.color = actionscolors[0]; 
            break;

            case Action.playerActions.Truth:
            ActionsIcon.color = actionscolors[1];
            break;

            case Action.playerActions.Kill:
            ActionsIcon.color = actionscolors[2];
            break;

            case Action.playerActions.Lie:
            ActionsIcon.color = actionscolors[3];
            break;

            default:
                Debug.Log("No se recnonce esa acción");
            break;
        }
        Invoke("HideIcons", 4);
    }

    private void HideIcons()
    {
        StatusIcon.gameObject.SetActive(false);
        ActionsIcon.gameObject.SetActive(false);
    }

    public void ShowHD()
    {
        textDialogue.text= ShowDialogue(7, States.playerStates.Good);
        ShowIcon(States.playerStates.Good);
    }

    public void ShowVD()
    {
        textDialogue.text = ShowDialogue(7, States.playerStates.Bad);
        ShowIcon(States.playerStates.Bad);
    }

    public void ShowSD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Save);
       ShowIcon(Action.playerActions.Save);
    }
    public void ShowTD() 
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Truth);
       ShowIcon(Action.playerActions.Truth);
    }

    public void ShowKD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Kill);
       ShowIcon(Action.playerActions.Kill);
    }

    public void ShowLD()
    {
       textDialogue.text = ShowDialogue(2, Action.playerActions.Lie);
       ShowIcon(Action.playerActions.Lie);
    }
}
