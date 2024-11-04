using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class Enemy 
{
    public float speed, damage, health; 
    protected GameObject _obj;
    protected Rigidbody _rb;
    
    public Enemy(float speed, Rigidbody rb, GameObject obj, float damage, float health) //constructor general de los personajes
    {
        this.speed = speed;
        this.damage = damage;
        _rb = rb;
        _obj = obj;
        
    }
    public float GetDamage()  // el metodo que aparecera en los hijos para el daño 
    {
        return damage;
    }

   

    public virtual void Attack()
    {

    } 

    
}
