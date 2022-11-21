/*
Name: Itteba Gilani
Purpose: PauseMenu
Date: Nov 7, 2021
*/

//Import necessary packages

using UnityEngine;
using UnityEngine.SceneManagement;

//Class PauseMenu inherits MonoBehaviour(from Unity)

public class PauseMenu : MonoBehaviour
{   
    //Global variable

    public static bool GameIsPaused = false;

    //Reference variable
    public GameObject PauseMenuUI;

    // Update is called once per frame

    void Update()
    {
        //If Esc is pressed, and game is paused, resume, and vice versa
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);       //Make the pauseMenuUI invisible
        Time.timeScale = 1f;                //Set time to normal speed
        GameIsPaused = false;               
    }

    void Pause() 
    {
        PauseMenuUI.SetActive(true);        //Make the PauseMenu visible
        Time.timeScale = 0f;                //Freeze time
        GameIsPaused = true;
    }

    public void LoadMenu()
    {   
        Time.timeScale = 1f;                //Set time to normal speed
        SceneManager.LoadScene("Menu");     //Load the menu scene
    }

    
}
