using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageOption : MonoBehaviour
{
    public Sprite[] sprites;
    private Image imageComponent;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }
    public void ChangeImage(int index)
    {
        imageComponent.sprite = sprites[index];
    }
}
