using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public float executeDelay;

    public void StartGame()
    {
        Invoke("ExecuteLoad", executeDelay);
    }

    public void QuitGame()
    {
        Invoke("ExecuteQuit", executeDelay);
    }

    private void ExecuteLoad()
    {
        SceneManager.LoadScene(1);
    }

    private void ExecuteQuit()
    {
        Application.Quit();
    }


}
