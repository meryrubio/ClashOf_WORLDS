using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{

    private Animator animator;
    private Player_movement player_Movement;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player_Movement = GetComponent<Player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Control de Idle/Walk según velocidad
        float speed = player_Movement.GetCurrentSpeed();
        animator.SetFloat("Speed", speed);

    }
    public void PlayShootAnimation()
    {
        animator.SetTrigger("Shoot");
    }
    private void LateUpdate()
    {
        float speed = player_Movement.GetCurrentSpeed();

        // Si el personaje se está moviendo (aunque sea despacio), activar animación de andar
        animator.SetFloat("Speed", speed);


        //animator.SetFloat("Speed", player_Movement.GetCurrentSpeed() / player_Movement.runningSpeed);
    }
}

