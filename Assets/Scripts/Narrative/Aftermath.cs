using UnityEngine;

public class Aftermath : MonoBehaviour
{
    [SerializeField] private States.playerStates PlayerStatus;
    [SerializeField] private int HistoryLevel;


    // Start is called before the first frame update
    void Start()
    {

        ShowNarrativeDialogue();
    }

    /// <summary>
    /// Asgina el nivel narrativo.
    /// </summary>
    /// <param name="level"></param>
    public void SetNarrativeLevel(int level)
    {
        HistoryLevel = level;
    }

    /// <summary>
    /// Obtiene el nivel narrativo.
    /// </summary>
    /// <returns>
    /// El nivel narrativo del juego.
    /// </returns>
    public int GetNarrativeLevel() 
    {
        return HistoryLevel;
    }

    /// <summary>
    /// Muestra los diálogos narrativos.
    /// </summary>
    public void ShowNarrativeDialogue()
    {
        NarrativeManager.Instance.ShowHistoryDialogue(HistoryLevel, PlayerStatus);
    }
}

