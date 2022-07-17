using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public string newGameLevel;
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
