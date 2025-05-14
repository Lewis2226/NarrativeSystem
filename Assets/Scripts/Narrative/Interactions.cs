using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Start is called before the first frame update

    public Action.playerActions actionUse;
    private States.playerStates playerState;
    public TextAsset InteractionDialogue;
    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogueManager.ReadCSV(InteractionDialogue, 2);
        SetAction(Action.playerActions.Kill);
        dialogueManager.ShowDialogue(1, actionUse);
        
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
