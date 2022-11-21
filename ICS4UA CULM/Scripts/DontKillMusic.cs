/*
Name: Itteba Gilani
Purpose: To not kill the music after loading new scenes
Date: Nov 7, 2021
*/

//Import necessary packages
using UnityEngine;
using UnityEngine.SceneManagement;

//DontKillMusic class inherits Monobehaviour(from Unity)

public class DontKillMusic : MonoBehaviour
 {

    private static DontKillMusic _instance;                
    
    //Called when scene loaded

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if(!_instance)
            _instance = this;

        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);
 
        //Don't destroy object(audio) won load
        DontDestroyOnLoad(this.gameObject);

    }

    //Called every frame
    void Update()
    {
        //If the scene is the main menu, destroy the background music for the levels
        if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                Destroy(this.gameObject);
            }    
    }
 }
