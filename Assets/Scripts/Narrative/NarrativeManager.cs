using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public States.playerStates currentState;
    public States.playerStates playerStates;
    public int currentNarrativeLevel;
    public int heroPointsTotal;
    public int villanPointsTotal;
    public int[] actionsPointsTotal = new int[5];

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChangePlayerState(int heroPoints,int villanPoints,int level)
    {
        switch (level)
        {
            
        }
    }

    public void ActiveEvent()
    {

    }

    private void ChangeWorld()
    {

    }

    void ShowHistoryDialogue()
    {

    }

    void NPCDialogue()
    {

    }
}
