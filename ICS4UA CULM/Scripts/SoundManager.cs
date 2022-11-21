/*
Name: Itteba Gilani
Purpose: Manage sound in game
Date: Nov 7, 2021
*/

//Import necessary packages
using UnityEngine;
using UnityEngine.UI;

//Class SoundManager inherits Monobehaviour(from Unity)
public class SoundManager : MonoBehaviour
{
    //Volume slider to appear in editor

    [SerializeField] Slider volumeSlider;


    // Start is called before the first frame update

    void Start()
    {   
        //If the playerPrefs(unity) doesn't have the key "musicVolume", "musicVolume" is equal to 1(100%)
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } 
        //Else load whatever has been saved from previous run
        else 
        {
            Load(); 
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;      //The volume is equal to the value of the volumeSlider
        Save();                                         //Save settings                                           
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");   //Load whatever volume settings had been previously saved
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);    //Save the volume value to the key, "musicVolume"
    }
    
}
