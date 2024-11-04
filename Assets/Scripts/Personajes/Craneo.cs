using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ClashofWorlds
{
    public class Craneo : PlayableCharacter
    {
        public Craneo(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("smooth"), 50, 100, 0.1F)
        {
        }

        
    }
}
