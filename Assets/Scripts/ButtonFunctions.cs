using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;

    [SerializeField] private GameObject menuPause;

    private bool pauseGame = false;
    //este un script de capa intermedia para que los gamemanager al cambiar de escena no se rayen, y los boyones puedan volver a funcionar de nuevoy asi no pierden la referencia, ya que no se van destruyendo.
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void LoadCharacter(int CharacterIndex)
    {
        GameManager.instance.characterType = (Characters)CharacterIndex;

        foreach (Transform child in transform.parent)
        {
            child.SendMessage("ChangeImage", CharacterIndex, SendMessageOptions.DontRequireReceiver);// sendmessage recorre cada uno de los componentes del objeto y comprueba que tenga el changeimage


        }


    }

    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }

    public void Resume()
    {
        pauseGame = false;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void AudioClip(AudioClip clip)
    {
        AudioSource audiosource = AudioManager.instance.PlayAudio(clip, "button");
    }

}
