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
        //Instantiate(prefab);
        //Instantiate(prefab);


        // Dispositivo 1: teclado
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            PlayerInput.Instantiate(prefab,
                controlScheme: "Keyboard&Mouse",
                pairWithDevice: keyboard);
        }

        // Dispositivo 2: gamepad
        var gamepad = Gamepad.all.Count > 0 ? Gamepad.all[0] : null;
        if (gamepad != null)
        {
            PlayerInput.Instantiate(prefab,
                controlScheme: "Gamepad",
                pairWithDevice: gamepad);
        }
        else
        {
            Debug.LogWarning("No se encontró ningún gamepad conectado.");
        }
    }


    private void Update()
    {
        //bool joinpressed = GetComponent<PlayerInput>().actions.FindActionMap("Player").FindAction("Join").triggered;
        //if (joinpressed)
        //{
        //}
    }

}
