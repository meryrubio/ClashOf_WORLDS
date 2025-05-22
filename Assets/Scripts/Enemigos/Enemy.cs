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

    public Enemy(float speed, Rigidbody rb, float damage, float health) : base(5, rb, Resources.Load<GameObject>("Enemy"), 1000, 100)//constructor general de los personajes
    {

    }

    public override void Attack(GameObject owner)
    {

    }

    public override void Death(GameObject owner)
    {
        if (health <= 0)
        {
          GameManager.instance.IncreaseScore(1);
          health = 100;
            owner.GetComponentInChildren<Animator>()?.Play("die");
            
            //owner.SetActive(false);
            onDeath.Invoke();
        }
    }
}
    
    
    
