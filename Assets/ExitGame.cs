using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            exitGame();
        }
    }

    public void exitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
