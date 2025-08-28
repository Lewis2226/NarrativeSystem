using UnityEngine;

[CreateAssetMenu(fileName = "Events", menuName = "ScriptableObjects/Eventos del juego", order = 1)]

public class Events : ScriptableObject
{
    public int eventId;
    public int stage;
    public string eventName;
    public States.playerStates moral;
    public Action.playerActions actionToComplete;
    public int duration;
    public bool failed;
    public bool completed;
    public TextAsset eventDialogues;

}
