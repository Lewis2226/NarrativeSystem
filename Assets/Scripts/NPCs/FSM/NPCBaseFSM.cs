using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBaseFSM : StateMachineBehaviour
{
    public GameObject NPC;
    public NavMeshAgent agent;
    public GameObject target;
    public float speed = 2f;
    public float rotationspeed = 1f;
    public float accuracy = 3f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       NPC = animator.gameObject;
       target= NPC.GetComponent<NPCAI>().target;
       agent = animator.GetComponent<NavMeshAgent>();
    }

    
}
