using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.GridLayoutGroup;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false) 
            { 
                pauseMenu.SetActive(true);
                pause = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (pause == true)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pause = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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

}
