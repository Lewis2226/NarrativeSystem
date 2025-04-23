using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    // Start is called before the first frame update

    public Action.playerActions ActionUse; 
    void Start()
    {
        ActionUse = Action.playerActions.Kill;
        Debug.Log($"El jugador uso la accion de  {ActionUse}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
