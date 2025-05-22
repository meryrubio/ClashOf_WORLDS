using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupBehaviour : MonoBehaviour
{
    public powerupEnum powerupType;
    private Powerups powerup;
    // Start is called before the first frame update
    void Start()
    {
        switch (powerupType)
        {
            case powerupEnum.SHOOTINGSPEED:
                powerup = new ShootingSpeed();
                break;
            case powerupEnum.RESTAUREHEALTH: 
                powerup = new RestaureHealth(); 
                break;
            case powerupEnum.SPEEDINCREASE: 
                powerup = new SpeedIncrease();
                break;
            case powerupEnum.DAMAGEINCREASE: 
                powerup = new DamageIncrease();
                break;
        }

        GetComponent<MeshFilter>().mesh = powerup.GetMesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player_movement>())
        {
            powerup.takePower(other.gameObject);
            Destroy(gameObject);
        }
    }

    
}
