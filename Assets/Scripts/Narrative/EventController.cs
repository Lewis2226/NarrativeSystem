using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public List<Events> activedEvents = new List<Events>();
    public static EventController Instance { get; private set; }

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

   public Events FindEvent(int eventID)
   {
        Events eventFind = activedEvents.Find(d => d.eventId == eventID);
        if (eventFind != null)
        {
            return eventFind;
        }
        else
        {
            return null;
        }
   } 

    public void AddEvent(List<Events> eventsToAdd)
    {
        foreach(Events e in eventsToAdd)
        {
            activedEvents.Add(e);
        }
    }

    public void RemoveEvent() 
    {
        foreach (Events e in activedEvents)
        {
            if(e.failed == true || e.completed == true)
            {
                activedEvents.Remove(e);
            }
        }
    }

    public void ChechkEvents(States.playerStates playerStates, Action.playerActions ActionUse)
    {
        foreach(Events e in activedEvents)
        {
            if(e.failed == true && e.moral != playerStates) 
            {
                RemoveEvent();
            }
            else if (e.completed == true) { }
            {
                RemoveEvent();
            }
        }
    }

    public void Setfailed(Events eventFailed)
    {
       FindEvent(eventFailed.eventId).failed = true;
    }

    public void ShowEvent(int eventId, int dilaogueType, int dialogueID, States.playerStates dialogueState)//Mostar Eventos Narrativos
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventdialogues, dilaogueType);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(dialogueID, dialogueState));

    }

    public void ShowEvent(int eventId, int dilaogueType, int level, Action.playerActions dialogueAction)//Mostar Eventos Interraciones
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventdialogues, dilaogueType);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(level, dialogueAction));

    }

    public void ShowEvent(int eventId, int dilaogueType, int dialogueID)//Mostar dialogos Sequenciales
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventdialogues, dilaogueType);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(dialogueID));

    }

    public void EventComplete(int id,Action.playerActions ActionUse)
    {
        if(FindEvent(id).actionToComplete == ActionUse)
        {
            FindEvent(id).completed = true;
        }
        else
        {
            FindEvent(id).failed = true;
        }
    }
}
