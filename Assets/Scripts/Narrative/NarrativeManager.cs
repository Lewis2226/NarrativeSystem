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

    // Update is called once per frame
    void Update()
    {
        
    }
}
