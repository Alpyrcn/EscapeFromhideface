using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonUI : MonoBehaviour
{
    public string levelName;
    public void PlayAgain()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
