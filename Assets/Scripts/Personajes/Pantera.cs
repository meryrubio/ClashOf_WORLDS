using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClashofWorlds
{
    public class Pantera : PlayableCharacter
    {
        public Pantera(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("FuriaMordada"), 10, 100, 1) 
        {
        }

    }
}
