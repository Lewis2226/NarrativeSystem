using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public Stages[] GameStages;
    int currentStage = 0;
    private int maxPhase;
    private int currentPhase;
    private States.playerStates playerState;

    public static StageSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetStage(currentStage, GameStages[currentStage].phases, GameStages[currentStage].name);
    }

    // Update is called once per frame
    void Update()
    {
        if (StageCheck())
        {
            Debug.Log("Se completo la etapa");
        }
        
    }

    /// <summary>
    /// Revisa el estado de la etapa.
    /// </summary>
    /// <returns>
    /// Regresa el estado de la etapa.
    /// </returns>
    bool StageCheck()
    {
        return GameStages[currentStage].completed;
    }

    /// <summary>
    /// Cambia a la siguiente fase de la etapa.
    /// </summary>
    public void NextPhase()
    {
        if(currentPhase < maxPhase)
        {
            currentPhase++;
            Debug.Log("La fase actual es: " + currentPhase);
        }
        else
        {
            currentPhase = maxPhase;
            CompleteStage();
            NextStage();
            Debug.Log("La fase actual es: " + currentPhase);
        }
        
    }

    /// <summary>
    /// Asigna la etapa como completada.
    /// </summary>
    public void CompleteStage()
    {

        if (currentPhase == maxPhase)
        {
            GameStages[currentStage].completed = true;
            WayofComplete(playerState);
        }
    }

    /// <summary>
    /// Cambia la siguiente etapa.
    /// </summary>
    public void NextStage()
    {
        if (StageCheck())
        {
            if(currentStage <= GameStages.Length)
            {
                currentStage++;
                SetStage(currentStage, GameStages[currentStage].phases, GameStages[currentStage].name);
                Debug.Log("Se cambio a la etapa : " + GameStages[currentStage].stageName);
            }
            else
            {
                Debug.Log("Ya no hay más etapas");
            }
        }
    }

    /// <summary>
    /// Asigna la etapa.
    /// </summary>
    /// <param name="Phase"></param>
    /// <param name="maxphase"></param>
    /// <param name="StageName"></param>
    void SetStage(int Phase, int maxphase, string StageName)
    {
        currentPhase = Phase;
        maxPhase = maxphase;
        string name = StageName;
    }

    /// <summary>
    /// Revisa la forma de Completar la etapa.
    /// </summary>
    /// <param name="status"></param>
    public void WayofComplete(States.playerStates status)
    {
        GameStages[currentStage].stateHowCompleted = status;
        Debug.Log(GameStages[currentStage].stateHowCompleted);
    }

    /// <summary>
    /// Agrega eventos a la lista de eventos. 
    /// </summary>
    /// <returns></returns>
    public List<Events> AddEvents()
    {
        List<Events> list = new List<Events>();
        list = GameStages[currentStage].toAdd;
        return list;
    }

    /// <summary>
    /// Muestra los evenots de interacciones.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="dilaogueType"></param>
    /// <param name="level"></param>
    /// <param name="dialogueAction"></param>
    public void ShowEvent(int eventId, int dilaogueType, int level, Action.playerActions dialogueAction)
    {
        EventController.Instance.ShowEvent(eventId, dilaogueType, level, dialogueAction);
    }
}
