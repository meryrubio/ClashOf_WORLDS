using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.UI.GridLayoutGroup;

public class CharacterManager : MonoBehaviour
{

    public float speed;
    public ClashofWorlds.PlayableCharacter character; //variable protejida para los personajes
    Animator animator;
    private float currentTime;
    
    private Player_Animations playerAnimations;
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
        Camera.main.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 0.81f, obj.transform.position.z);
      
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= character.rate && Input.GetAxis("Fire1") != 0)
        {
            currentTime = 0;
            character.Attack(gameObject);

            if (playerAnimations != null)
                playerAnimations.PlayShootAnimation();
            //Animator animator = owner.GetComponent<Animator>();
            //animator.SetBool(blendParameter, true);
        }
        
    }
   
}
