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

    /// <summary>
    /// Buscar un evento de la lista de eventos, tomando en cuenta el id del este.
    /// </summary>
    /// <param name="eventID"></param>
    /// <returns>
    /// El evento, de lo contrario, regresa nulo
    /// </returns>
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

    /// <summary>
    /// Agregar una lista de eventos a la lista de eventos activos, tomando en cuenta la lista de evetos que añadir.
    /// </summary>
    /// <param name="eventsToAdd"></param>
    public void AddEvent(List<Events> eventsToAdd)
    {
        foreach(Events e in eventsToAdd)
        {
            activedEvents.Add(e);
        }
    }

    /// <summary>
    /// Quita eventos de la lista de eventos, los que se quitan son los completados o los fallidos.
    /// </summary>
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

    /// <summary>
    /// Revisa los eventos para determinar si se completraon o se fallaron.
    /// </summary>
    /// <param name="playerStates"></param>
    /// <param name="ActionUse"></param>
    public void CheckEvents(States.playerStates playerStates, Action.playerActions ActionUse)
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

    /// <summary>
    /// Asigna al evento seleccionado como fallido, al evento dado.
    /// </summary>
    /// <param name="eventFailed"></param>
    public void Setfailed(Events eventFailed)
    {
       FindEvent(eventFailed.eventId).failed = true;
    }

    /// <summary>
    /// Asigna al evento seleccionado con completado, tomando en cuenta la accion usada por el jugador.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ActionUse"></param>
    public void EventComplete(int id, Action.playerActions ActionUse)
    {
        if (FindEvent(id).actionToComplete == ActionUse)
        {
            FindEvent(id).completed = true;
        }
        else
        {
            FindEvent(id).failed = true;
        }
    }

    /// <summary>
    /// Muestra eventos narrativos.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="dilaogueType"></param>
    /// <param name="dialogueID"></param>
    /// <param name="dialogueState"></param>
    public void ShowEvent(int eventId, int dilaogueType, int level, States.playerStates dialogueState)
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventDialogues, dilaogueType);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(level, dialogueState));

    }

    /// <summary>
    /// Muestra los eventos de interacciones.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="dilaogueType"></param>
    /// <param name="level"></param>
    /// <param name="dialogueAction"></param>
    public void ShowEvent(int eventId, int dilaogueType, int level, Action.playerActions dialogueAction)
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventDialogues, dilaogueType);
        Debug.Log("A");
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(level, dialogueAction));
        Debug.Log("B");

    }

    /// <summary>
    /// Muestra eventos sequenciales
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="dilaogueType"></param>
    /// <param name="dialogueID"></param>
    public void ShowEvent(int eventId, int dilaogueType, int dialogueID)
    {
        DialogueManager.Instance.ReadCSV(FindEvent(eventId).eventDialogues, dilaogueType);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(dialogueID));

    }
}
