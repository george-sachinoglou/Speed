using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void TryAgainBtn(string AgainGameLevel)
    {
        SceneManager.LoadScene(AgainGameLevel);
    }

    public void MainMenuBtn(string mainMenuScreen)
    {
        SceneManager.LoadScene(mainMenuScreen);
    }
    
    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
