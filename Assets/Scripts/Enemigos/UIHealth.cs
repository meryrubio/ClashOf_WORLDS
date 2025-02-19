using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    public TMP_Text text;
    private EnemyTypeReference typeReference;

    // Start is called before the first frame update
    void Start()
    {
        typeReference = GetComponent<EnemyTypeReference>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = typeReference.enemyType.health.ToString();
    }
}
