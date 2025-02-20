using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    public Image barraDeVida;
    private EnemyTypeReference typeReference;

    // Start is called before the first frame update
    void Start()
    {
        typeReference = GetComponent<EnemyTypeReference>();
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = typeReference.enemyType.health/100;
    }
}
