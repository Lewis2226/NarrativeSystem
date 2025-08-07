using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public Stages[] GameStages;
    int currentStage = 0;
    private int maxPhase;
    private int currentPhase;

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

    bool StageCheck()
    {
        return GameStages[currentStage].completed;
    }

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

    public void CompleteStage()
    {
        if (currentPhase == maxPhase)
        {
            GameStages[currentStage].completed = true;
            WayofComplete(States.playerStates.Good);
        }
    }


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

    void SetStage(int Phase, int maxphase, string StageName)
    {
        currentPhase = Phase;
        maxPhase = maxphase;
        string name = StageName;
    }

    public void WayofComplete(States.playerStates status)
    {
        GameStages[currentStage].stateHowCompleted = status;
        Debug.Log(GameStages[currentStage].stateHowCompleted);
    }

    public List<Events> AddEvents()
    {
        List<Events> list = new List<Events>();
        list = GameStages[currentStage].toAdd;
        return list;
    }

    public void ShowEvent(int eventId, int dilaogueType, int level, Action.playerActions dialogueAction)//Eventos Interactivos
    {
        EventController.Instance.ShowEvent(eventId, dilaogueType, level, dialogueAction);
    }
}
