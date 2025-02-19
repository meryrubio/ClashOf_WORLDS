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
       
    }

    private void LateUpdate()
    {
        //animator.SetFloat("Speed", player_Movement.GetCurrentSpeed() / player_Movement.runningSpeed);
    }
}

