using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioClip deadClip; //audio de muerte

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        AudioManager.instance.PlayAudio(deadClip, "deadSound");
    }
    public void Menu(string MenuName)
    {
        SceneManager.LoadScene(MenuName);
    }

    public void Exit()
    {
        Debug.Log("EXIT!!");
        Application.Quit();
    }

    //public void Restart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
}
