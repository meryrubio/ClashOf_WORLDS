using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum powerupEnum {SHOOTINGSPEED, RESTAUREHEALTH,SPEEDINCREASE,DAMAGEINCREASE}
public abstract class Powerups 
{
    private Mesh mesh;

    public Powerups(Mesh mesh) { this.mesh = mesh;  }
    public abstract void takePower(GameObject player);

    public Mesh GetMesh() { return mesh; }  
}
