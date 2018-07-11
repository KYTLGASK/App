using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSript : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("TheGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        //GameObject.Find("OptionsMenu").SetActive(true);
        GameObject.Find("MainMenu").SetActive(false);
    }


}
