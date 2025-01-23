using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " HearAction (A)", menuName = "ScriptableObjects/Actions/HearAction")]

public class HearAction : Action
{
    public float radius ;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up); // castea una esfera alrededor del enemigo 
        GameObject target = owner.GetComponent<TargetReferences>().target; // accedemos al target

        foreach (RaycastHit hit in hits) // recorremos todos los objetos que estemos escuchando si alguno es el objetivo devuelvo true si no false 
        {
            if (hit.collider.gameObject == target)
            {
                //le hemos escuchado / oler

                return true;
            }
        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }
}
