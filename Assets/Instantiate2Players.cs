using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Instantiate2Players: MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Awake()
    {
            Instantiate(prefab);
            Instantiate(prefab);
    }

    private void Update()
    {
        //bool joinpressed = GetComponent<PlayerInput>().actions.FindActionMap("Player").FindAction("Join").triggered;
        //if (joinpressed)
        //{
        //}
    }

}
