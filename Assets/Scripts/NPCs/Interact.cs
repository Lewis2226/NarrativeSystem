
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    public int NPCEvent;
    public Action.playerActions action;
    public GameObject dialgueCanvas;
    public TextAsset dialogueNarrative;
    public TextAsset dialogueSequences;
    public TextMeshProUGUI textoNPCs;


    private void Start()
    {
        DialogueManager.Instance.ReadCSV(dialogueNarrative, 1);
        DialogueManager.Instance.ReadCSV(dialogueSequences, 4);
        DialogueManager.Instance.ShowDialogue(1, States.playerStates.Good);
        NarrativeManager.Instance.NPCsDialogue(3);
        DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogueSequences(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialgueCanvas.SetActive(true);
            EventController.Instance.ShowEvent(NPCEvent, 2, 1, action);
        }
    }
}
