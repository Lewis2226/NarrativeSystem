using UnityEngine;

public class HeroOrVillain : MonoBehaviour
{

   [SerializeField] private States.playerStates PlayerState;
   [SerializeField] private int GoodPoints;
   [SerializeField] private int BadPoints;
   [SerializeField] private int EventChoosen;
   

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
   /// El actual estado del jugador.
   /// </returns>
   public States.playerStates GetState()
   {
        return PlayerState;
   }
   
    /// <summary>
    /// Asgina los puntos de estado del jugador, para el estado seleccionado.
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
    /// Obtiene los puntos de estado del jugador.
    /// </summary>
    /// <param name="PointsType"></param>
    /// <returns>
    /// Los puntos del estado bueno o malo, depenediendo del estado asignado.
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
