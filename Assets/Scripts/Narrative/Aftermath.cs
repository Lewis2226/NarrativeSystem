using UnityEngine;

public class Aftermath : MonoBehaviour
{
    [SerializeField] private States.playerStates PlayerStatus;
    [SerializeField] private int HistoryLevel;
    [SerializeField] private string NarrativeDialogue;
    private DialogueManager dialogueManager;
    public TextAsset DialoguesNarrative;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GetComponent<DialogueManager>();
        dialogueManager.ReadCSV(DialoguesNarrative, 1);
        ShowNarrativeDialogue(1, States.playerStates.Good);
    }

    public void SetNarrativeLevel(int level)
    {
        HistoryLevel = level;
    }

    public int GetNarrativeLevel() 
    {
        return HistoryLevel;
    }

    public string ShowNarrativeDialogue(int level, States.playerStates NarrativeType)
    {
        NarrativeDialogue = dialogueManager.ShowDialogue(level, NarrativeType);
        Debug.Log(NarrativeDialogue);
        return NarrativeDialogue;
    }
}

