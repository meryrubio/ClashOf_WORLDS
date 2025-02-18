using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObjects/States/ChaseState")] // nos habilita la opcion de cogerlo en el create

public class ChaseState : State
{
    public string blendParameter;
    public override State Run(GameObject owner)
    {


        State nextState = CheckActions(owner); //ejecutamos el checkactions

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>(); // el owner es el que tiene el objeto 
        if (!navMeshAgent.isOnNavMesh) 
        {
            navMeshAgent.Warp(owner.transform.position);
        }
        Animator animator = owner.GetComponent<Animator>();
        GameObject target = owner.GetComponent<TargetReferences>().target; // para que persiga al objetivo 

        navMeshAgent.SetDestination(target.transform.position); // dice al agente que su destino es el transform del objetivo y esquivara los obstaculos para llegar al objetivo
        
        //animator?.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        return nextState;
    }
}
