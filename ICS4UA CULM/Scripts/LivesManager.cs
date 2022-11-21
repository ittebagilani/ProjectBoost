/*
Name: Itteba Gilani
Purpose: Manages lives
Date: Nov 7, 2021
*/

//Import necessary package
using UnityEngine;
using UnityEngine.SceneManagement;

//Clas LivesManager inherits Monobehaviour(from Unity)
public class LivesManager : MonoBehaviour
{
    public GameObject[] hearts;     //hearts array stores images of hearts
    public static int life = 5;     //5 lives in total

    // Update is called once per frame
    void Update()
    {   

        switch(life) 
        {
            case 5:
                //Set all hearts to visisble
                hearts[0].gameObject.SetActive (true);
                hearts[1].gameObject.SetActive (true);
                hearts[2].gameObject.SetActive (true);
                hearts[3].gameObject.SetActive (true);
                hearts[4].gameObject.SetActive (true);
                break;
            case 4:
                //Set the right most heart to invisible
                hearts[0].gameObject.SetActive (true);
                hearts[1].gameObject.SetActive (true);
                hearts[2].gameObject.SetActive (true);
                hearts[3].gameObject.SetActive (true);
                hearts[4].gameObject.SetActive (false);
                break;
            case 3:
                //Set the 2 right most hearts to invisible
                hearts[0].gameObject.SetActive (true);
                hearts[1].gameObject.SetActive (true);
                hearts[2].gameObject.SetActive (true);
                hearts[3].gameObject.SetActive (false);
                hearts[4].gameObject.SetActive (false);
                break;
            case 2:
                //Set the 3 right most hearts to invisible
                hearts[0].gameObject.SetActive (true);
                hearts[1].gameObject.SetActive (true);
                hearts[2].gameObject.SetActive (false);
                hearts[3].gameObject.SetActive (false);
                hearts[4].gameObject.SetActive (false);
                break;
            case 1:
                //Set the 4 right most hearts to invisible
                hearts[0].gameObject.SetActive (true);
                hearts[1].gameObject.SetActive (false);
                hearts[2].gameObject.SetActive (false);
                hearts[3].gameObject.SetActive (false);
                hearts[4].gameObject.SetActive (false);
                break;
            case 0:
                //Set all hearts to invisible
                hearts[0].gameObject.SetActive (false);
                hearts[1].gameObject.SetActive (false);
                hearts[2].gameObject.SetActive (false);
                hearts[3].gameObject.SetActive (false);
                hearts[4].gameObject.SetActive (false);
                
                //Print "game over"
                Debug.Log("GAME OVER");

                //Call GameOver after 2 second delay
                Invoke("GameOver", 2f);
                break;
        }
    }

    public void TakeDamage(int d = 1)
    {
        life -= d;      //Decrement lives according to user's choice
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);      //Load menu    
        life = 5;                       //Set lives back to 5
    }
}
