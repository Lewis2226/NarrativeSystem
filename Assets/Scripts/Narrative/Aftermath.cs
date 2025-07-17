using UnityEngine;

public class Aftermath : MonoBehaviour
{
    [SerializeField] private States.playerStates PlayerStatus;
    [SerializeField] private int HistoryLevel;
    [SerializeField] private string NarrativeDialogue;
    
    public TextAsset DialoguesNarrative;

    // Start is called before the first frame update
    void Start()
    {
        NarrativeManager.Instance.ReadDialogue(DialoguesNarrative, 1);

        ShowNarrativeDialogue();
    }

    public void SetNarrativeLevel(int level)
    {
        HistoryLevel = level;
    }

    public int GetNarrativeLevel() 
    {
        return HistoryLevel;
    }

    public void ShowNarrativeDialogue()
    {
        NarrativeManager.Instance.ShowHistoryDialogue(HistoryLevel, PlayerStatus);
    }
}

