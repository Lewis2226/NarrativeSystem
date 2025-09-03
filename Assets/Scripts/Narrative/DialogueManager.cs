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
    [Tooltip("Lista de los diálogos narrativos, no es necsario agregar nada está se llena automáticamente")]
    public List<HistoryDialogue> dialoguesHistory;
    [Tooltip("Lista de los diálogos de interacción, no es necsario agregar nada está se llena automáticamente")]
    public List<DialogueInteraction> dialoguesInteraction;
    [Tooltip("Lista de los diálogos de los NPCs, no es necsario agregar nada está se llena automáticamente")]
    public List<DialogueNPCs> dialoguesNPCs;
    [Tooltip("Lista de los diálogos de sequecuenciales, no es necsario agregar nada esta se llena automáticamente")]
    public List<DialogueSequences> dialoguesSequence;
    [Tooltip("Csv para los diálogos de los NPCs")]
    public TextAsset dialoguesNPcs;
    [Tooltip("text Mesh Pro para mostrar los diálogos en pantalla, el unico tipo de diálogos no se muestra son los de los NPCs")]
    public TextMeshProUGUI textDialogue;
    [SerializeField] private float typewriterSpeed = 0.2f;
    private int currentDialogueID = 1;
    private string currentDialogue;
    private bool isTyping = false;
    private bool canSkip = false;

    public static DialogueManager Instance { get; private set; }

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }


    private void Start()
    {

    }

    /// <summary>
    /// Permite leer los archivos csv, recibe una arhivo csv y el tipo de diálogo.
    /// </summary>
    /// <param name="DialoguesList"></param>
    /// <param name="DialoguesTypes"></param>
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

    /// <summary>
    /// Obtiene diálogos narrativos, usando el id del diálogo.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Statetypes"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
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

    /// <summary>
    /// Obtiene los diálogos de interraciones, tomando en cuenta el id del diálogo.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="actionstype"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
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

    /// <summary>
    /// Obtiene los dialgos de los NPCs, tomando el nivel del juego.
    /// </summary>
    /// <param name="GameLevel"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
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

    /// <summary>
    /// Obtiene los diálogos sequenciales, tomando en cuenta el id del diálogo.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
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

    /// <summary>
    /// Muestra el siguiente diálogo sequencial.
    /// </summary>
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

    /// <summary>
    /// Salta la corrutina de maquina de escribir y muestra el diálogo de manera inmediata.
    /// </summary>
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

    /// <summary>
    /// Muestra los diálogos en este caso los narrativos.
    /// </summary>
    /// <param name="dialogueId"></param>
    /// <param name="dialogueState"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
    public string ShowDialogue(int dialogueId, States.playerStates dialogueState)
    {
        string dialogueToShow = GetDialogueNarratve(dialogueId, dialogueState);
        return dialogueToShow;
    }


    /// <summary>
    /// Muestra los diálogos en este caso los de interraciones.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="actionType"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
    public string ShowDialogue(int level, Action.playerActions actionType) 
    {
        string dialogueToShow = GetDialogueInteraction(level, actionType);
        return dialogueToShow;
    }

    /// <summary>
    /// Muestra los diálogos en este caso los de NPCs.
    /// </summary>
    /// <param name="GameLevel"></param>
    /// <returns>
    /// Los regresa en fomato string.
    /// </returns>
    public string ShowDialogue(int GameLevel) 
    {
        string dialogueToShow = GetDialogueNPCs(GameLevel);
        return dialogueToShow;
    }

    /// <summary>
    /// Muestra los dialogos sequenciales.
    /// </summary>
    /// <param name="DialogueID"></param>
    /// <returns>
    /// Los regresa en formato string.
    /// </returns>
    public string  ShowDialogueSequences(int DialogueID) 
    {
        string dialogueToShow = GetDialogueSequence(DialogueID);
        return dialogueToShow; 
    }

    /// <summary>
    /// Vacia la lista de diálogos de las interraciones y los sequenciales.
    /// </summary>
    public void ClearDialogueLists()
    {
        dialoguesInteraction.Clear();
        dialoguesSequence.Clear();

    }

    /// <summary>
    /// Corrutina para mostrar los diálogos con si fuera una máquina de escribir.
    /// </summary>
    /// <param name="Dialogue"></param>
    /// <returns>
    /// Este muestra cada letra tomando en cuenta el valor de typewriterSpeed.
    /// </returns>
    public IEnumerator Typewriter(string Dialogue)
    {
        textDialogue.text = "";
        foreach (char letter in Dialogue)
        {
            textDialogue.text += letter;
            yield return new WaitForSeconds(typewriterSpeed);
        }
        isTyping = false;
    }
}
