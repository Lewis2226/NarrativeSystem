using UnityEngine;
using UnityEngine.UI;

public class NarrativeManager : MonoBehaviour
{
    private States.playerStates currentState;
    private States.playerStates playerStates;
    public int currentNarrativeLevel;
    private int heroPointsTotal;
    private int villanPointsTotal;
    private int[] actionsPointsTotal = new int[4];
    public Color[] actionscolors = new Color[4];
    public Image StatusIcon;
    public Image ActionsIcon;
    public TextAsset dialogueTest;
    
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

        //ChangePlayerState(13, 5, 1);
        //playerStates = States.playerStates.Bad;
        //NPCsDialogue();
        //ChangeWorld(playerStates, 1);
    }

    /// <summary>
    /// Cambia el estado del jugador, tomando en cuenta los puntos de heróe, villano y el nivel del juego.
    /// </summary>
    /// <param name="heroPoints"></param>
    /// <param name="villanPoints"></param>
    /// <param name="level"></param>
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
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el primer capítulo como heróe");
                }
                else if(villanPoints >heroPoints && villanPoints >= 10 )
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 5;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el primer capítulo como villano");
                }    
            break;

            case 2:
                if(heroPoints > villanPoints && heroPoints >= 20)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 10;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el segundo capítulo como heróe");
                }
                else if(villanPoints> heroPoints && villanPoints >= 20)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 10;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el segundo capítulo como villano");
                }
            break;

            case 3:
                if (heroPoints > villanPoints && heroPoints >= 30)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 15;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el tercer capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 30)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 15;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el tercer capítulo como villano");
                }
            break;

            case 4:
                if(heroPoints > villanPoints && heroPoints >= 40)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 20;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el cuarto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 40)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal =20;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el cuarto capítulo como villano");
                }
            break;

            case 5:
                if(heroPoints > villanPoints && heroPoints >= 50)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 25;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el quinto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 50)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 25;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el quinto capítulo como villano");
                }
            break;

            case 6:
                if(heroPoints > villanPoints && heroPoints >= 60)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 30;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el sexto capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >=60)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 30;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el sexto capítulo como villano");
                }
            break;

            case 7:
                if(heroPoints > villanPoints && heroPoints >= 70)
                {
                    playerStates = States.playerStates.Good;
                    heroPointsTotal = 35;
                    villanPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el septimo capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 70)
                {
                    playerStates = States.playerStates.Bad;
                    villanPointsTotal = 35;
                    heroPointsTotal = 0;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el septimo capítulo como villano");
                }
            break;

            case 8:
                if(heroPoints > villanPoints && heroPoints >= 80)
                {
                    playerStates = States.playerStates.Good;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el octavo capítulo como heróe");
                }
                else if(villanPoints > heroPoints && villanPoints >= 80)
                {
                    playerStates = States.playerStates.Bad;
                    StageSystem.Instance.NextPhase();
                    Debug.Log("Se termino el octavo capítulo como villano");
                }
            break;

            default:
            Debug.Log("No existe ese nivel narrativo");
            break;
        }
    }

    /// <summary>
    /// Activa los eventos narrativos.
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="playerStates"></param>
    /// <param name="dialogueID"></param>
    public void ActiveEvent(int eventId,States.playerStates playerStates, int dialogueID)
    {
        EventController.Instance.ShowEvent(eventId,1,dialogueID, playerStates);
    }

    /// <summary>
    /// Cambia el estado del mundo, tomando el cuenta el estado del jugador y el nivel del juego.
    /// </summary>
    /// <param name="playerState"></param>
    /// <param name="GameLevel"></param>
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

            case 2:
                if (playerState == States.playerStates.Good)
                {
                    Debug.Log("El mundo cambio por ser bueno");
                }
                else if (playerState == States.playerStates.Bad)
                {
                    Debug.Log("El mundo cambio por ser malo");
                }
                break;

            case 3:
                if (playerState == States.playerStates.Good)
                {
                    Debug.Log("El mundo cambio por ser bueno");
                }
                else if (playerState == States.playerStates.Bad)
                {
                    Debug.Log("El mundo cambio por ser malo");
                }
                break;

            default:
                Debug.Log("No se encuentra ese nivel Narrativo");
            break;      


        }
    }

    /// <summary>
    /// Lee los csv de los dialogos.
    /// </summary>
    /// <param name="DialoguesList"></param>
    /// <param name="DialoguesTypes"></param>
   public void ReadDialogue(TextAsset DialoguesList, int DialoguesTypes)
   {
        DialogueManager.Instance.ReadCSV(DialoguesList, DialoguesTypes);
   }

   /// <summary>
   /// Muestra los diálogos narrativos.
   /// </summary>
   /// <param name="level"></param>
   /// <param name="dialogueState"></param>
   public void ShowHistoryDialogue(int level , States.playerStates dialogueState)
   {
        StartCoroutine(DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(level, dialogueState)));
        ShowIcon(playerStates);
   }

    /// <summary>
    /// Muestra los diálogos de interacciones.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="actionType"></param>
    public void ShowInteractionsDialogue(int level, Action.playerActions actionType)
    {
        StartCoroutine(DialogueManager.Instance.Typewriter(DialogueManager.Instance.ShowDialogue(level, actionType)));
        
    }

    /// <summary>
    /// Muestra los dialogos de los NPCs.
    /// </summary>
    public void NPCsDialogue()
    {
        DialogueManager.Instance.ShowDialogue(1);
    }

    /// <summary>
    /// Muestra los iconos de los estados del jugador.
    /// </summary>
    /// <param name="Status"></param>
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

    /// <summary>
    /// Muestralos iconos de las acciones.
    /// </summary>
    /// <param name="ActionUse"></param>
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
                Debug.Log("No se recononce esa acción");
                break;
        }
        Invoke("HideIcons", 4f);
    }

    /// <summary>
    /// Oculta los iconos sin importar el tipo.
    /// </summary>
    private void HideIcons()
    {
        StatusIcon.gameObject.SetActive(false);
        ActionsIcon.gameObject.SetActive(false);
    }
}
