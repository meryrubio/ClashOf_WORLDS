using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : Powerups
{
    public SpeedIncrease() : base(null)
    {
    }

    public override void takePower(GameObject player)
    {
        player.GetComponent<Player_movement>().walkingSpeed *= 2;
        player.GetComponent<Player_movement>().runningSpeed *= 2;
    }
}
