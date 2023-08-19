using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void playGame()
    {
        //load next scene 1
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        //quit game
        Application.Quit();
    }


}
