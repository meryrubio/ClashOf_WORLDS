using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncrease : Powerups
{
    public DamageIncrease() : base(null)
    {
    }
    public override void takePower(GameObject player)
    {
        player.GetComponent<CharacterManager>().character.damage *= 2;
    }
}
