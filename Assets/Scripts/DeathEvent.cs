using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEvent : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
