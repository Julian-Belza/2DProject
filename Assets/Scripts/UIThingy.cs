using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIThingy : MonoBehaviour
{
    public void onClickStartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void onClickMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onClickHelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void onClickQuit()
    {
        Application.Quit();
    }
}
