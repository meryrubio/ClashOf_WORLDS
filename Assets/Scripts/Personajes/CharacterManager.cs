using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{

    public float speed;
    protected ClashofWorlds.Character character; //variable protejida para los personajes
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();

        //programamos un if para elegir para la funcion del boton para elegir el personaje
        if (GameManager.instance.characterType == Characters.CRANEO)
        {
            character = new ClashofWorlds.Craneo(speed, GetComponent<Rigidbody>());
        }
        else if (GameManager.instance.characterType == Characters.GHOSTFACE)
        {
            character = new ClashofWorlds.GhostFace(speed, GetComponent<Rigidbody>());
        }
        else if (GameManager.instance.characterType == Characters.PANTERA)
        {
            character = new ClashofWorlds.Pantera(speed, GetComponent<Rigidbody>());
        }
        GameObject obj = Instantiate(character.GetObject(), transform.position, Quaternion.identity, transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}