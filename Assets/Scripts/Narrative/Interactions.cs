using UnityEngine;

public class Interactions : MonoBehaviour
{
    
    public Action.playerActions actionUse;
    private States.playerStates playerState;
    public TextAsset InteractionDialogue;

    void Start()
    {
        NarrativeManager.Instance.ReadDialogue(InteractionDialogue, 2);
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
