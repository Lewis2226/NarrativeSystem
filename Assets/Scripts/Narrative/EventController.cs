using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public List<Events> activedEvents = new List<Events>();


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
            if(e.failed == true)
            {
                activedEvents.Remove(e);
            }
        }
    }

    public void ChechkEvents(States.playerStates playerStates)
    {
        foreach(Events e in activedEvents)
        {
            if(e.failed == true && e.moral != playerStates) 
            {
                RemoveEvent();
            }
            else
            {
                //Conexión con el Stage System
            }
        }
    }

    public void Setfailed(Events eventFailed)
    {
       FindEvent(eventFailed.eventId).failed = true;
    }

    public void ShowEvent(int id)
    {
      //Conexión con dialogue Manager
    }
}
