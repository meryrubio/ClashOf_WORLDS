using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClashofWorlds //crea un espacio de nombres para evitar la colision de nombres
{
    public abstract class Character
    {
        //informacion de los players
        private Animator _animator;
        //private AnimatorController _controller;
        
      
        public float speed, damage, health, rate;
        protected GameObject _obj;
        protected Rigidbody _rb;
        public GameObject bullet; 

        public Character(float speed, Rigidbody rb, GameObject obj , float damage, float rate) //constructor general de los personajes
        {
            this.speed = speed;
            _rb = rb;
            _obj = obj;
            bullet = Resources.Load<GameObject>("bullet"); // para crear la bala
            this.rate = rate; 
            //_controller = cont;

        }
        public GameObject GetObject() { return _obj; } //se genere el sprite


        //public AnimatorController GetAnimatorController() { return _controller; } //animaciones
        public float GetDamage()  // el metodo que aparecera en los hijos para el daño 
        {
            return damage;
        }
       
        public virtual float Heal() //el metodo que aparecera en los hijos para la vida 

        {
            Debug.Log("Character se cura");
            health = Mathf.Clamp(health, 0, 100);  // lo clampeamos para que al curarse no sobrepase los 100 de vida 
            return health;
        }
        public virtual void Attack(Transform ownerTransform)
        { 
          GameObject.Instantiate(bullet, ownerTransform.position, Quaternion.identity); 
        }
        
    }
}
