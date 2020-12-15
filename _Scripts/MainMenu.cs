using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject HowToPlayScreen;
    public GameObject NewGameScreen;

    public void NewGamePressed()
    {
        NewGameScreen.SetActive(true);
        TitleScreen.SetActive(false);
    }

    public void HowToPlayPressed()
    {
        HowToPlayScreen.SetActive(true);
        TitleScreen.SetActive(false);
    }

    public void BackToMenuPressed()
    {
        TitleScreen.SetActive(true);
        HowToPlayScreen.SetActive(false);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
