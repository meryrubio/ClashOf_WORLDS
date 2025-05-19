using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCanvas : MonoBehaviour
{
    public Canvas[] canvas;
    // Start is called before the first frame update
    void Start()
    {
        Player_movement[] players = FindObjectsOfType<Player_movement>();

        int i = 0;
        foreach (Player_movement item in players)
        {
            canvas[i].worldCamera = item.GetComponentInChildren<Camera>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
