using UnityEngine;

public class Interactions : MonoBehaviour
{
    [Tooltip("La acción usada por el jugador en las interraciones con los NPCs")]
    public Action.playerActions actionUse;
    private States.playerStates playerState;


    void Start()
    {
        NarrativeManager.Instance.ShowInteractionsDialogue(1, actionUse);
        SetAction(Action.playerActions.Kill);   
    }

    /// <summary>
    /// Asinga la accion del jugador.
    /// </summary>
    /// <param name="action"></param>
    public void SetAction(Action.playerActions action)
    {
        actionUse = action;
    }

    /// <summary>
    /// Asigna el estado del jugador.
    /// </summary>
    /// <param name="state"></param>
    public void SetPlayerState(States.playerStates state)
    {
        playerState = state;
    }
}
