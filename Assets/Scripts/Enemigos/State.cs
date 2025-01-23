using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionParameters // para relacionar la accion con el booleano
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("Indicates if the action´s check must be true or false")]
    public bool actionValue;
}


[System.Serializable]
public struct StateParameters
{

    public ActionParameters[] actionParameters;
    [Tooltip("If the action´s check equals actionValue, nextState is pushed")]
    public State nextState;
    [Tooltip("Se cumplen todas las acciones o solo se tiene que cumplir una?")]
    public bool and;
}
public abstract class State : ScriptableObject
{
    public StateParameters[] stateParameters;

    protected State CheckActions(GameObject owner)
    {
        for (int i = 0; i < stateParameters.Length; i++) //recorremos el array de los parametros 
        {
            bool todasLasAccionesSeHanCumplido = true;
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++) // en cada uno de nuestros parametros tenemos otro array que debemos recorrer
            {
                ActionParameters actionParameter = stateParameters[i].actionParameters[j];
                if (actionParameter.action.Check(owner) == actionParameter.actionValue)
                {
                    if (!stateParameters[i].and) // si solo se tiene que cumplir una 
                    {
                        // devolvemos directamente el siguiente estado
                        return stateParameters[i].nextState;
                    }
                }
                else if (stateParameters[i].and)
                {
                    todasLasAccionesSeHanCumplido = false;
                    break; // salimos del bucle, porque una acción no se ha cumplido y estamos en and 
                }
            }
            // si llegamos hasta aqui, significa que el disenyador ha marcado que todas las acciones tienen que cumplirse. Tenemos que comprobar si de verdad se han cumplido todas
            if (stateParameters[i].and && todasLasAccionesSeHanCumplido)
            {
                return stateParameters[i].nextState;
            }
        }
        return null; // ninguna accion se cumple, por lo que no cambiamos de estado 
    }
    public abstract State Run(GameObject owner); //el abstract es porque el run no hace nada definido 

    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameters in stateParameters)
        {
            foreach (ActionParameters aP in parameters.actionParameters)
            {
                aP.action.DrawGizmo(owner);
            }
        }
    }
}
