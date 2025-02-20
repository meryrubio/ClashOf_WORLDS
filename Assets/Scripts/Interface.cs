using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Image Vida;
    CharacterManager cm;

    public void vidaCharacter()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vida.fillAmount = cm.character.health/200;
    }
}
