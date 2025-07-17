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

    public void SetState(States.playerStates NewState)
    {
        PlayerState = NewState;
    }

   public States.playerStates GetState()
   {
        return PlayerState;
   }

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

   public void ShowNarrative()
   {
        NarrativeManager.Instance.ShowHistoryDialogue(NarrativeManager.Instance.currentNarrativeLevel ,PlayerState);
   }
}
