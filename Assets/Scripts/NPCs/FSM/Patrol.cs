using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM
{
     
    GameObject[] wayPoints;
    int currentWayPoint = 0;
    private NPCAI MyNPC;

    private void Awake()
    {
        wayPoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        agent.stoppingDistance = accuracy;
        agent.speed = speed;
        agent.angularSpeed = rotationspeed;
        MyNPC = NPC.GetComponent<NPCAI>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(wayPoints[currentWayPoint].transform.position , NPC.transform.position)< accuracy)
        {
            
            currentWayPoint++;
            if (currentWayPoint >= wayPoints.Length)
            {
                currentWayPoint = 0;
            }
            NPC.GetComponent<Animator>().SetBool("waiting", true);
        }
        agent.SetDestination(wayPoints[currentWayPoint].transform.position);
    }

}
