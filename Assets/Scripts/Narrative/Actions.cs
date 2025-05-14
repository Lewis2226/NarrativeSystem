using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public int scoreToGive;

    
    // Start is called before the first frame update
    void Start()
    {
        SetScore(5, Action.playerActions.Kill, States.playerStates.Bad);
        print(scoreToGive);
    }

    public void SetScore(int score, Action.playerActions actionType, States.playerStates playerStatus)
    {
        switch (playerStatus)
        {
            case States.playerStates.Good:
                if(actionType == Action.playerActions.Kill)
                {
                    score = score * 3;
                    scoreToGive = score;
                }
                else if (actionType == Action.playerActions.Lie)
                {
                    score = score * 2;
                    scoreToGive = score;
                }
                else
                {
                    scoreToGive = score;
                } 
                break;


            case States.playerStates.Bad:
                if (actionType == Action.playerActions.Save)
                {
                    score = score * 3;
                    scoreToGive = score;
                }
                else if (actionType == Action.playerActions.Truth)
                {
                    score = score * 2;
                    scoreToGive = score;
                }
                else
                {
                    scoreToGive = score;
                }
                break;

            default:
                Debug.Log("No se reconoce el estado");
                break;

        }
    }

    public int GetScore() 
    {
      return scoreToGive;
    }

}
