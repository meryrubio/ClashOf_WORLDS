using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
   
}
