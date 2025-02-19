using ClashofWorlds;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Enemy : Character
{
    public delegate void DeathEventHandler();

    // El evento público que otros scripts pueden suscribirse para ser notificados cuando el enemigo "muera"
    public event DeathEventHandler onDeath;

    public Enemy(float speed, Rigidbody rb, float damage, float health) : base(5, rb, Resources.Load<GameObject>("Enemy"), 10, 100)//constructor general de los personajes
    {

    }

    public override void Attack(GameObject owner)
    {

    }

    public override void Death()
    {
        base.Death();
        onDeath.Invoke();
    }

    public override void ReceiveDamage(float damage)
    {
        Debug.Log("me hace daño");
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }
}
    
    
    
