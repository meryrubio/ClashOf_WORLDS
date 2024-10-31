using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClashofWorlds
{
    public class Craneo : Character
    {
        public Craneo(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("smooth"))
        {
        }

        
    }
}
