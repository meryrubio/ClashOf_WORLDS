using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpeed : Powerups
{
    public ShootingSpeed() : base(null)
    {
    }

    public override void takePower(GameObject player)
    {
        player.GetComponent<CharacterManager>().character.rate *= 2;
    }
}
