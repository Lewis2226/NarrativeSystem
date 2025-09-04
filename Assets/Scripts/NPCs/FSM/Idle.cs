using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : NPCBaseFSM
{
    public float waitTime = 3f;
    private float elapsedTime = 0f;
    private NPCAI MyNPC;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        base.OnStateEnter(animator, stateInfo, layerIndex);
        agent.speed = speed;
        target = NPC;
        agent.SetDestination(target.transform.position);
        MyNPC = NPC.GetComponent<NPCAI>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(target.transform.position);
       elapsedTime += Time.deltaTime;
       if(elapsedTime >= waitTime) 
       {
            elapsedTime = 0f;
            NPC.GetComponent<Animator>().SetBool("waiting", false); 
       }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
