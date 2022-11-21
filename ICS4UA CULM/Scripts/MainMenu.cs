/*
Name: Itteba Gilani
Purpose: Main Menu screen
Date: Nov 7, 2021
*/

//Import necessary packages
using UnityEngine;
using UnityEngine.SceneManagement;

//Class MainMenu inherits Monobehaviour(from Unity)
public class MainMenu : MonoBehaviour
{   

    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Load the first level
    }

    public void QuitGame() 
    {   
        Debug.Log("QUIT");      //Print Quit and then quit game
        Application.Quit();
    }

}
