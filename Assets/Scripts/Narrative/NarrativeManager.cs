using UnityEngine;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    public States.playerStates currentState;
    public States.playerStates playerStates;
    public int currentNarrativeLevel;
    public int heroPointsTotal;
    public int villanPointsTotal;
    public int[] actionsPointsTotal = new int[5];
    private DialogueManager dialogueManager;
    public Color[] actionscolors = new Color[4];
    public Image StatusIcon;
    public Image ActionsIcon;
    
    public static NarrativeManager Instance { get; private set; }

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

    void Start()
    {
       
        dialogueManager = GetComponent<DialogueManager>();
        ChangePlayerState(13, 5, 1);
        //playerStates = States.playerStates.Bad;
        NPCsDialogue();
        ChangeWorld(playerStates, 1);
    }

    public void ChangePlayerState(int heroPoints,int villanPoints,int level)
    {
        switch (level)
        {
            case 1: 
                if(heroPoints > villanPoints && heroPoints >= 10)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 5;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el primer cap�tulo como her�e");
                }
                else if(villanPoints >heroPoints && villanPoints >= 10 )
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 5;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el primer cap�tulo como villano");
                }    
            break;

            case 2:
                if(heroPoints > villanPoints && heroPoints >= 20)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 10;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el segundo cap�tulo como her�e");
                }
                else if(villanPoints> heroPoints && villanPoints >= 20)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 10;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el segundo cap�tulo como villano");
                }
            break;

            case 3:
                if (heroPoints > villanPoints && heroPoints >= 30)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 15;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el tercer cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 30)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 15;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el tercer cap�tulo como villano");
                }
            break;

            case 4:
                if(heroPoints > villanPoints && heroPoints >= 40)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 20;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el cuarto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 40)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal =20;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el cuarto cap�tulo como villano");
                }
            break;

            case 5:
                if(heroPoints > villanPoints && heroPoints >= 50)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 25;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el quinto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 50)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 25;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el quinto cap�tulo como villano");
                }
            break;

            case 6:
                if(heroPoints > villanPoints && heroPoints >= 60)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 30;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el sexto cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >=60)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 30;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el sexto cap�tulo como villano");
                }
            break;

            case 7:
                if(heroPoints > villanPoints && heroPoints >= 70)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 35;
                    villanPointsTotal = 0;
                    Debug.Log("Se termino el septimo cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 70)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 35;
                    heroPointsTotal = 0;
                    Debug.Log("Se termino el septimo cap�tulo como villano");
                }
            break;

            case 8:
                if(heroPoints > villanPoints && heroPoints >= 80)
                {
                    playerStates = States.playerStates.Good;
                    Debug.Log("Se termino el octavo cap�tulo como her�e");
                }
                else if(villanPoints > heroPoints && villanPoints >= 80)
                {
                    playerStates = States.playerStates.Bad;
                    Debug.Log("Se termino el octavo cap�tulo como villano");
                }
            break;

            default:
            Debug.Log("No existe ese nivel narrativo");
            break;
        }
    }

    public void ActiveEvent(int savepoints, int truthpoints, int killpoints, int liepoints, Event.gameEvents EventToSelect)
    {
        switch (EventToSelect)
        {
            case Event.gameEvents.Dialogue:
                Debug.Log("Se mostro un dialogo");
            break;

            case Event.gameEvents.Submission:
                Debug.Log("Se dio una submission");
            break;

            default:
                Debug.Log("No se reconoce ese evento");
            break;

        }
    }


    private void ChangeWorld(States.playerStates playerState , int GameLevel)
    {
        switch(GameLevel)
        {
            case 1:
                if(playerState == States.playerStates.Good)
                {
                  Debug.Log("El mundo cambio por ser bueno");
                }
                else if(playerState == States.playerStates.Bad)
                {
                  Debug.Log("El mundo cambio por ser malo");
                }
            break;

            default:
                Debug.Log("No se encuentra ese nivel Narrativo");
            break;      


        }
    }

   public void ReadDialogue(TextAsset DialoguesList, int DialoguesTypes)
   {
        dialogueManager.ReadCSV(DialoguesList, DialoguesTypes);
   }

   public void ShowHistoryDialogue(int level , States.playerStates dialogueState)
   {
        dialogueManager.ShowDialogue(level, dialogueState);
        ShowIcon(playerStates);
   }

    public void ShowInteractionsDialogue(int level, Action.playerActions actionType)
    {
        dialogueManager.ShowDialogue(level , actionType);
    }

    public void NPCsDialogue()
    {
        dialogueManager.ShowDialogue(1);
    }

    public void ShowIcon(States.playerStates Status)
    {

        StatusIcon.gameObject.SetActive(true);
        if (Status == States.playerStates.Good)
        {
            StatusIcon.color = Color.blue;
        }

        else if (Status == States.playerStates.Bad)
        {
            StatusIcon.color = Color.red;
        }
        Invoke("HideIcons", 4);
    }

    public void ShowIcon(Action.playerActions ActionUse)
    {
        ActionsIcon.gameObject.SetActive(true);
        switch (ActionUse)
        {
            case Action.playerActions.Save:
                ActionsIcon.color = actionscolors[0];
                break;

            case Action.playerActions.Truth:
                ActionsIcon.color = actionscolors[1];
                break;

            case Action.playerActions.Kill:
                ActionsIcon.color = actionscolors[2];
                break;

            case Action.playerActions.Lie:
                ActionsIcon.color = actionscolors[3];
                break;

            default:
                Debug.Log("No se recononce esa acci�n");
                break;
        }
        Invoke("HideIcons", 4f);
    }

    private void HideIcons()
    {
        StatusIcon.gameObject.SetActive(false);
        ActionsIcon.gameObject.SetActive(false);
    }

    public void SIG()
    {
        ShowIcon(States.playerStates.Good);
    }

    public void SIB()
    {
        ShowIcon(States.playerStates.Bad);
    }

    public void SIS() 
    {
        ShowIcon(Action.playerActions.Save);
    }

    public void SIT()
    {
        ShowIcon(Action.playerActions.Truth);
    }

    public void SIK()
    {
        ShowIcon(Action.playerActions.Kill);
    }

    public void SIL()
    {
        ShowIcon(Action.playerActions.Lie);
    }
}
