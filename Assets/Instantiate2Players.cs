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


        // dispositivo 1: teclado
        //var keyboard = keyboard.current;
        //if (keyboard != null)
        //{
        //    var player1 = playerinput.instantiate(prefab,
        //        controlscheme: "keyboard&mouse",
        //        pairwithdevice: keyboard);

        //    // asigna cráneo
        //    player1.getcomponent<player_movement>().charactertype = characters.craneo;
        //}

        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            PlayerInput.Instantiate(prefab,
                controlScheme: "Keyboard&Mouse",
                pairWithDevice: keyboard);


            //}

            // Dispositivo 2: gamepad
            // GhostFace con mando
            //var gamepad = Gamepad.all.Count > 0 ? Gamepad.all[0] : null;
            //if (gamepad != null)
            //{
            //    var player2 = PlayerInput.Instantiate(prefab,
            //        controlScheme: "Gamepad",
            //        pairWithDevice: gamepad);

            //    // Asigna GhostFace
            //    player2.GetComponent<Player_movement>().characterType = Characters.GHOSTFACE;
            //}

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

    }
    private void Update()
    {
        //bool joinpressed = GetComponent<PlayerInput>().actions.FindActionMap("Player").FindAction("Join").triggered;
        //if (joinpressed)
        //{
        //}
    }

}
