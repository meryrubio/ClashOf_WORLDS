using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{

    [SerializeField] private GameObject buttonPause;

    [SerializeField] private GameObject menuPause;

    private bool pauseGame = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseGame)
                Resume();
            else
                Pausa();

        }
    }

    public void Pausa()
    {
        pauseGame = true;
        Time.timeScale = 0;
        buttonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        pauseGame = false;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Restart()
    {
        pauseGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Debug.Log("Cerrando El Juego");
        Application.Quit();
    }

    public void ChangeScene()
    {
        pauseGame = false;
        Time.timeScale = 1f;
    }
}
