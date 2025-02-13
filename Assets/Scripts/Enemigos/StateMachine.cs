using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {

        State nextState = currentState.Run(gameObject); // para que recorra el run todo el rato 

        if (nextState) // si nextstate no es nulo cambiamos al siguiente estado 
        {
            currentState = nextState;
        }

        // aqui hay que ejecutar el estado y si en algun momento el estado cambia tenemos que cambiar el current state, relacionar el currentState con el run 
    }

    private void OnDrawGizmos()
    {
        if (currentState)// si no tiene el circulo lo dbuja
            currentState.DrawAllActionsGizmos(gameObject);
        else
            initialState.DrawAllActionsGizmos(gameObject);

    }
}
