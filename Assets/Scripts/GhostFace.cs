using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ClashofWorlds
{
    public class GhostFace : Character
    {
        public GhostFace(float speed, Rigidbody rb) : base(speed, rb, Resources.Load<GameObject>("GhostFace"))
        {
        }


    }
}
