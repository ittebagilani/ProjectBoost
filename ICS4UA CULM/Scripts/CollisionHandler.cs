/*
Name: Itteba Gilani
Purpose: Handles all collision between player and obstacles/enemies
Date: Nov 7, 2021
*/

//Improt necessary packages

using UnityEngine;
using UnityEngine.SceneManagement;

//CollisionHandler class inherits MonoBehaviour(from Unity)

public class CollisionHandler : MonoBehaviour
{   
    //Instantiate a LivesManager object

    LivesManager obj = new LivesManager();

    //Private Reference variables
    AudioSource audioSource;
    public GameObject CompleteLevelUI;

    //Private variables available in editor
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
   
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    

    //Private variables
    bool isTransitioning = false;
    bool collisionDisabled = false;
  
    //Called once game is launced

    void Start()
    {
        //Get the AudioSource component and store in assigned reference variable

        audioSource = GetComponent<AudioSource>();
        
    }

    //Called once every frame

    void Update()
    {   
        RespondToDebugKeys();
    }

    
    //Function responsible for thrust/cheat codes
    void RespondToDebugKeys() {

        //If L is pressed, skip level
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            LoadNextLevel();
        }

        //If C is pressed, collision is disabled
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;     //toggle collision
        } 
    }

    //Unity function for handling collision
    void OnCollisionEnter(Collision other)
    {
        //If collision disabled or moving to new scene, return

        if (isTransitioning || collisionDisabled) return;

        //If the player lands on an object with the tag, "Friendly", output "Good Luck" to console

        if(other.gameObject.tag.Equals("Friendly"))
        {
            Debug.Log("Good luck!");
        } 

        //If the player lands on an object with the tag, "Finish" and the scene is not the last level, call StartSuccessSequence()
        else if(other.gameObject.tag.Equals("Finish") && SceneManager.GetActiveScene().buildIndex != 5)
        {
            StartSuccessSequence();
        } 

        //If the player lands on an object with the tag, "Finish" and the scene is the last level, call 
        //CompletedGame() first and StartSuccessSequence() after 5 seconds
        else if(other.gameObject.tag.Equals("Finish") && SceneManager.GetActiveScene().buildIndex == 5)
        {
            CompletedGame();
            Invoke("StartSuccessSequence", 5f);
        }
        
        //Otherwise, crash
        else 
        {
            StartCrashSequence(); 
        }
    }


    //Makes the CompleteLevelUI visible
    void CompletedGame()
    {
        CompleteLevelUI.SetActive(true);
    }

    
    void StartSuccessSequence()
    {
        successParticles.Play();                    //Play the success particles
        isTransitioning = true;                     //Set isTransitioning to "true"
        audioSource.Stop();                         //Stop the rocket booster audio
        audioSource.PlayOneShot(success);           //Play the success aduio
        GetComponent<Movement>().enabled = false;   //Take control away from player
        Invoke("LoadNextLevel", levelLoadDelay);    //Load next level after specified value
    }

    void StartCrashSequence()
    {
        crashParticles.Play();                      //Play the crash particles
        isTransitioning = true;                     //Set isTransitioning to "true"
        audioSource.Stop();                         //Stop the rocket booster audio
        audioSource.PlayOneShot(crash);             //Play the crash audio
        GetComponent<Movement>().enabled = false;   //Take control away from player
        obj.TakeDamage(1);                          //Take 1 damage and remove 1 life
        Invoke("ReloadLevel", levelLoadDelay);      //Reload level after specified value
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   //Get the buildIndex of the current active scene and assign

        int nextSceneIndex = currentSceneIndex + 1;                         

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);                             //Load the next scene

    }

    void ReloadLevel()
    {
 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;   //Get the buildIndex of the current active scene and assign
        SceneManager.LoadScene(currentSceneIndex);                          //Reload the same scene
    }


}
