using ClashofWorlds;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Enemy : Character
{   
    public Enemy(float speed, Rigidbody rb, GameObject obj, float damage, float health) : base(speed, rb, obj, damage, health)//constructor general de los personajes
    {
        
    } 

    public override void Attack(Transform ownerTransform)
    {

    } 

    
}
