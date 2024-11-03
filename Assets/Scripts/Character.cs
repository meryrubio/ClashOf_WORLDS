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
        
        private string _name;
        public float speed, damage, health;
        protected GameObject _obj;
        protected Rigidbody _rb;
       

        public Character(float speed, Rigidbody rb, GameObject obj , float damage) //constructor general de los personajes
        {
            this.speed = speed;
            _rb = rb;
            _obj = obj;
            //_controller = cont;

        }
        public GameObject GetObject() { return _obj; } //se genere el sprite


        //public AnimatorController GetAnimatorController() { return _controller; } //animaciones
        public float GetDamage()  // el metodo que aparecera en los hijos para el daño 
        {
            return damage;
        }

        public string GetName() // el metodo que aparecera en los hijos para el nombre 

        {
            return _name;
        }
        public virtual float Heal() //el metodo que aparecera en los hijos para la vida 

        {
            Debug.Log("Character se cura");
            health = Mathf.Clamp(health, 0, 100);  // lo clampeamos para que al curarse no sobrepase los 100 de vida 
            return health;
        }
        public abstract float Attack(); // un metodo abstracto que no esta definido en la clase padre y que fuerzas a la clase hija 
    }
}
