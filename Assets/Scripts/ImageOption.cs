using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SelectionData // CREAMOS UNA STRUCTURA PARA LA SELECCCION DE PERSONAJE 
{
    public Sprite img;
    public string textSkill;
}

public class ImageOption : MonoBehaviour
{
    public SelectionData[] data;//creamos un array de seleccion

    private Image imageComponent;
    public TMP_Text textComponent;// Texto donde se mostrarán las habilidades
    public GameObject skillsPanel; // Panel que contiene el texto de habilidades

    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }
    public void ChangeImage(int index)
    {
        imageComponent.sprite = data[index].img;
        textComponent.text = data[index].textSkill;
    }
}
