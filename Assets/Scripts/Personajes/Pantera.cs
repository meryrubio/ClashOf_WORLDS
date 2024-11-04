using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClashofWorlds
{
    public class Pantera : Character
    {
        public Pantera(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("FuriaMordada"), 10, 1) 
        {
        }

    }
}
