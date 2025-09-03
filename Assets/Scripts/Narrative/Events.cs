using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObjects/Eventos del juego", order = 1)]

public class Events : ScriptableObject
{
    [Tooltip("Identificador de eventos para llamarlo en Event Controller")]
    public int eventId;
    [Tooltip("Indica la etapa en la que pasa")]
    public int stage;
    [Tooltip("Nombre del evento para mostrar en la UI")]
    public string eventName;
    [Tooltip("Moral en la que aparece el evento")]
    public States.playerStates moral;
    [Tooltip("Acción con la que se considera que el evento completado")]
    public Action.playerActions actionToComplete;
    [Tooltip("Indica cuanto dura el evento")]
    public int duration;
    private bool failed;
    private bool completed;
    public TextAsset eventDialogues;

    public bool GetFailed()
    {
        return failed;
    }

    public void SetFail(bool fail)
    {
        failed = fail;
    } 

    public bool GetCompleted()
    {
        return completed;
    }

    public void SetCompleted(bool complete)
    {
        completed = complete;
    }
}
