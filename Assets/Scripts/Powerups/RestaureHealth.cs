using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestaureHealth : Powerups
{
    public RestaureHealth() : base(Resources.Load<Mesh>("alienatacar2"))
    {
    }

    public override void takePower(GameObject player)
    {
        player.GetComponent<CharacterManager>().character.health += 5;
    }
}
