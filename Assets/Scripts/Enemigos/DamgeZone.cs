using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeZone : MonoBehaviour
{
   // public PlayerHealth health;
    private bool canDamage = true;
    private float CoolDown = 3f;

    public float radius = 8f;


    public void CreateZone()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, Vector3.up);
        //GameObject target = GetComponent<TargetReference>().targets[0]; //target, ubi del player

        foreach (RaycastHit hit in hits)
        {
            // verifica si el objeto golpeado tiene el componente Health
            //PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            //if (playerHealth != null) //verifica  si se encontro un componente PlayerHealth
            //                          //Si playerHealth no es null, significa que tiene un componente PlayerHealth
            //{
            //    health.TakeDamage(1);
            //    canDamage = false;
            //    StartCoroutine(CoolDownDamage());
            //}
        }

      


    }

  
    IEnumerator CoolDownDamage()
    {
        yield return new WaitForSeconds(CoolDown);
        canDamage = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
