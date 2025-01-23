using System.Collections;
using System.Collections.Generic;
using ClashofWorlds;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackState (S)", menuName = "ScriptableObjects/States/AttackState")]
public class AttackState : State
{
    public float attackRange = 2f; // Rango de ataque
    public float attackDamage = 10f; // Da�o del ataque
    public float attackCooldown = 5; // Tiempo de recarga entre ataques
    public float currentTime = 5; // Tiempo de recarga entre ataques
                                  // Tiempo del �ltimo ataque

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);
        // Verificar si hay un enemigo en rango
        GameObject player = FindPlayer(owner);
        if (player != null)
        {
            currentTime += Time.deltaTime;
            // Si el enemigo est� dentro del rango, atacar
            if (IsEnemyInRange(owner, player) && currentTime >= attackCooldown)
            {
                currentTime = 0;
                Attack(player);

            }
            else
            {
                // Si el enemigo est� fuera de rango, moverse hacia �l
                MoveTowardsEnemy(owner, player);
            }
        }
        else
        {
            // Si no hay enemigo, quiz�s regresar a un estado de patrullaje o inactivo
            return null; // Puede regresar a un estado anterior o a un estado inactivo
        }

        return nextState;

    }

    private GameObject FindPlayer(GameObject owner)
    {
        // Implementar l�gica para encontrar un enemigo cercano
        // Este es un ejemplo simple, puedes usar un sistema de detecci�n m�s sofisticado
        return owner.GetComponent<TargetReferences>().target;
    }

    private bool IsEnemyInRange(GameObject owner, GameObject player)
    {
        float distance = Vector3.Distance(owner.transform.position, player.transform.position);
        return distance <= attackRange;
    }

    private void Attack(GameObject player)
    {
        // Aqu� se implementa la l�gica de ataque
        //Por ejemplo, se puede hacer da�o al jugador
        
        //if (Health != null)
        //{
        //  playerHealth.Damage(attackDamage); 
        //}

        Debug.Log($"Attacked {player.name} for {attackDamage} damage!");
    }

    private void MoveTowardsEnemy(GameObject owner, GameObject player)
    {
        // Mover al objeto hacia el enemigo
        Vector3 direction = (player.transform.position - owner.transform.position).normalized;
        owner.transform.position += direction * Time.deltaTime; // Mover a la velocidad deseada
    }

}