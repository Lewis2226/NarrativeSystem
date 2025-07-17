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

    public void SetAction(Action.playerActions action)
    {
        actionUse = action;
    }

    public void SetPlayerState(States.playerStates state)
    {
        playerState = state;
    }
}
