using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SelectionData
{
    public Sprite img;
    public string textSkill;
}

public class ImageOption : MonoBehaviour
{
    public SelectionData[] data;

    private Image imageComponent;
    public TMP_Text textComponent;
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
