using UnityEngine;

public class HeroOrVillain : MonoBehaviour
{

   [SerializeField] private States.playerStates PlayerState;
   [SerializeField] private int GoodPoints;
   [SerializeField] private int BadPoints;
   [SerializeField] private string EventChoosen;
   

    void Start()
    {
        PlayerState = States.playerStates.Neutral;
    }

    /// <summary>
    /// Asgina el estado del jugador.
    /// </summary>
    /// <param name="NewState"></param>
    public void SetState(States.playerStates NewState)
    {
        PlayerState = NewState;
    }

   /// <summary>
   /// Obtiene el estado del jugador.
   /// </summary>
   /// <returns>
   /// Regresa el estado del jugador.
   /// </returns>
   public States.playerStates GetState()
   {
        return PlayerState;
   }
   
    /// <summary>
    /// Asgina los puntos de estado del jugador.
    /// </summary>
    /// <param name="PointsType"></param>
    /// <param name="amount"></param>
   public void SetPoints(States.playerStates PointsType, int amount)
   {
        if(PointsType == States.playerStates.Good)
        {
            GoodPoints += amount;
        }
        else
        {
            BadPoints += amount;
        }
   }

    /// <summary>
    /// Obtiene elos puntos de estado del jugador.
    /// </summary>
    /// <param name="PointsType"></param>
    /// <returns>
    /// Regresa los puntos del estado bueno o malo.
    /// </returns>
   public int GetPoints(States.playerStates PointsType)
   {
        if (PointsType == States.playerStates.Good)
        {
            return GoodPoints;
        }
        else
        {
            return BadPoints;
        }
   }

    /// <summary>
    /// Muestra los diálogos narrativos
    /// </summary>
   public void ShowNarrative()
   {
        NarrativeManager.Instance.ShowHistoryDialogue(NarrativeManager.Instance.currentNarrativeLevel ,PlayerState);
   }
}
