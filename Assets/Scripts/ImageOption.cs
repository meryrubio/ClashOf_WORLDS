using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct SelectionData // CREAMOS UNA STRUCTURA PARA LA SELECCCION DE PERSONAJE 
{
    
    public string textSkill;
    public Vector3 platformRotation;
}

public class ImageOption : MonoBehaviour
{
    public SelectionData[] data;//creamos un array de seleccion

    
    public TMP_Text textComponent;// Texto donde se mostrarán las habilidades
    public GameObject platform; // Panel que contiene el texto de habilidade
    public float platformSpeed;


    private void Start()
    {
        
    }

    public void ChangeImage(int index)
    {
        
        textComponent.text = data[index].textSkill;
        // StopCoroutine(RotatePlatform(data[index].platformRotation));
        StartCoroutine(RotatePlatform(data[index].platformRotation));
    }

    IEnumerator RotatePlatform(Vector3 rotation)
    {
        float angle = 360;
        while (angle > 1.0f)
        {
            // Debug.Log(platform.transform.localEulerAngles.y);
            Vector3 nDir = Vector3.RotateTowards(platform.transform.up, rotation, platformSpeed * Time.deltaTime, 0.0f);
            platform.transform.Rotate(nDir);
            //print(platform.transform.localEulerAngles.magnitude);
            //print(rotation.magnitude);
            angle = Mathf.Abs(platform.transform.localEulerAngles.magnitude - rotation.magnitude);
            //print(angle);

            yield return null;
        }
    }
}
