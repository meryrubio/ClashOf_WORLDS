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

        public float speed;
        protected GameObject _obj;
        protected Rigidbody _rb;
       

        public Character(float speed, Rigidbody rb, GameObject obj) //constructor general de los personajes
        {
            this.speed = speed;
            _rb = rb;
            _obj = obj;
            //_controller = cont;

        }
        public GameObject GetObject() { return _obj; } //se genere el sprite


        //public AnimatorController GetAnimatorController() { return _controller; } //animaciones
    }
}
